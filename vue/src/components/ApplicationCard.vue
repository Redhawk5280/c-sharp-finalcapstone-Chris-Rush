<template>
  <section 
    class="applicationCard" 
    >
    <div id="contactContainer">
        <h1>Name: {{application.appName}}</h1>
        <p>Email: {{application.appEmail}}</p>
        <p v-if="application.weekdayAvailability">Weekday Availability: Yes</p>
        <p v-else>Weekday Availability: No</p>
        <p v-if="application.weekendAvailability">Weekend Availability: Yes</p>
        <p v-else>Weekend Availability: No</p>
        <p>Interest: {{application.interest}}</p>
        
        
      </div>
      <div id="buttons" v-if="$store.state.user.role === 'admin'">
      <div v-if="application.isApproved == false">
        <button id="acceptBtn" v-on:click="ApproveApplication">Accept</button>
            <button id="denyBtn" v-on:click="DenyApplication">Deny</button>
        </div>
        <button v-else id="deactivateBtn" v-on:click="DeactivateUser">Deactivate</button>
      </div>
  </section>
</template>

<script>
import VolunteerService from '../services/VolunteerService';
import AuthService from '../services/AuthService'

export default {
  props: [
    'application'
  ],
  methods: {
    ApproveApplication(application){
      if(application.isApproved == false){
      application.isApproved= true
      VolunteerService.updateApplication(this.application).then(response=>
      {
        this.$store.commit("UPDATE_APPLICATION", application)
        
      }
      )
      .catch(response =>{
        console.log("there's been an issue")
      })
    }
  },
  DenyApplication(application){
      if(application.isApproved == true){
      application.isApproved= false
      VolunteerService.updateApplication(this.application).then(response=>
      {
        this.$store.commit("UPDATE_APPLICATION", application)
        
      }
      )
      .catch(response =>{
        console.log("there's been an issue")
      })
    }
  },
  DeactivateUser(user){
      if(user.role == "user"){
      user.role = "Deactivated"
      AuthService.UpdateUser(this.user).then(response=>
      {
        this.$store.commit("UPDATE_USER", user)
        
      }
      )
      .catch(response =>{
        console.log("there's been an issue")
      })
    }
  }

    
  },
  computed: { 
  }
}
</script>

<style scoped>
  .applicationCard {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    border-radius: 1rem;
    box-shadow: var(--generic-shadow);
    background-color: var(--company-color-1);
    overflow: none;
    position: relative;
    height: 100%;
    width: 100%;
    
    border-radius: 1rem;
    font-size: 2rem;
  }
  #contactContainer{
margin: 10% auto
  }
  #buttons{
    align-items:flex-end;
    margin-bottom: 3%;
  }

  .applicationCard h1,h2,p{
    margin: 0;
    padding: 0;
    font-family: var(--card-body-font);
    color: var(--company-color-2);
    max-width: 100%;
  }

  button {
    border: none;
    padding: 8px 16px;
    border-radius: 1rem;
    font-size: 2rem;
  }



  
</style>
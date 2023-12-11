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
        <p>Is Approved to Volunteer? {{ application.isApproved?"Yes":"No" }}</p>
        
        
      </div>
      <div id="buttons" v-if="$store.state.user.role === 'admin'">
      <div v-if="application.isApproved == null">
        <button id="acceptBtn" v-on:click="ApproveApplication(application)">Accept</button>
            <button id="denyBtn" v-on:click="DenyApplication(application)">Deny</button>
        </div>
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
    ApproveApplication(application) {

      application.isApproved = true;
      VolunteerService.updateApplication(application).then(response => {
        this.$store.commit("UPDATE_APPLICATION", application)
        this.$router.go();
      }
      )
        .catch(response => {
          console.log("there's been an issue")
        })
    },
    DenyApplication(application) {
      application.isApproved = false;
      VolunteerService.updateApplication(application).then(response => {
        this.$store.commit("UPDATE_APPLICATION", application)
        this.$router.go();
      }
      )
        .catch(response => {
          console.log("there's been an issue")
        })
    },
  }


};


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
    margin:  auto 0;
    width:100%;
    border-radius: 1rem;
    font-size: 1rem;
    padding: 5% 0;
    box-sizing: border-box;
  }
  
  #contactContainer{



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
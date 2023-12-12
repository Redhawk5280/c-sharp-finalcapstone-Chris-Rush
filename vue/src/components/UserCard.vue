<template>
  <section 
    class="userCard" 
    >
      <div id="contactContainer">
        <h1>Email: {{user.email}}</h1>
        <h1>Role: {{user.role}}</h1>
        <h1>Weekday Available: {{user.weekdayAvailable ? "Yes" : "No" }}</h1>
        <h1>Weekend Available: {{user.weekendAvailable ? "Yes" : "No" }}</h1>
        
      </div>
      <div id="buttons" v-if="$store.state.user.role === 'admin' && user.role != 'deactivated'">
        <button v-on:click="DeactivateUser(user.email)" v-if="user.email !== $store.state.user.email">Deactivate</button>
        <button v-on:click="PromoteUser(user.email)" v-if="user.role !== 'admin' ">Promote</button>

      </div>
  </section>
</template>

<script>
import VolunteerService from '../services/VolunteerService';
import AuthService from '../services/AuthService'

export default {
  props: [
    'user',
    
  ],
  methods: {

    DeactivateUser(email) {
      AuthService.deactivateUser(email).then(response => {
        this.$store.commit("UPDATE_USER", email)

      })
        .catch(response => {
          console.log("there's been an issue")
        })
    },
    PromoteUser(email) { 
      AuthService.promoteUser(email)
        .then(response => { 
        this.$store.commit("PROMOTE_USER", email)
        })
        .catch(response => { 
          console.log("there has been an issue with promoting a user");
        })
    }
  }


};


</script>

<style scoped>
    .userCard {
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

  .userCard h1,h2,p{
    margin: 0;
    padding: 0;
    font-family: var(--card-body-font);
    color: var(--company-color-2);
    max-width: 100%;
    font-size: 1rem;
  }

  button {
    border: none;
    padding: 8px 16px;
    border-radius: 1rem;
    font-size: 1rem;
    box-shadow: var(--general-shadow);
    color: var(--company-color-1);
    background-color: var(--company-color-2);
    z-index: 1;
  }
  button:hover {
    cursor: pointer;
  }

</style>
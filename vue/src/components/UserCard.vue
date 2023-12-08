<template>
  <section 
    class="userCard" 
    >
      <div id="contactContainer">
        <h1>Email: {{user.email}}</h1>
        <p>Role: {{user.role}}</p>
        <p>Weekday Available: {{user.WeekdayAvailable ? "Yes": "No"}}</p>
        <p>Weekend Available: {{user.WeekendAvailable ? "Yes": "No"}}</p>
        
      </div>
      <div id="buttons" v-if="$store.state.user.role === 'admin' && user.role != 'deactivated'">
        <button v-on:click="DeactivateUser(user.email)">Deactivate</button>
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
        console.log("uh ohhhhhhh")

      }
      )
        .catch(response => {
          console.log("there's been an issue")
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
  }
  #contactContainer{
margin: 10% auto;
object-fit: cover;

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
  }

  button {
    border: none;
    padding: 8px 16px;
    border-radius: 1rem;
    font-size: 2rem;
  }



  
</style>
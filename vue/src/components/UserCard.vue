<template>
  <section 
    class="applicationCard" 
    >
      <div id="contactContainer">
        <h1>Email: {{user.email}}</h1>
        <p>Role: {{user.role}}</p>
      </div>
      <div id="buttons" v-if="$store.state.user.role === 'admin'">
        <button>Deactivate</button>
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

    DeactivateUser(email) {
      AuthService.deactivateUser(email).then(response => {
        this.$store.commit("UPDATE_USER", email)

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
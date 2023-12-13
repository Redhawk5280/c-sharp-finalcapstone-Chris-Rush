<template>
  <div id="loadingDiv" v-if="isLoading">
    <img src="../assets/loading-gif/loading-dog.gif"/>
  </div>
  <div class="home" v-else>
    <h1 id="homeH1">Volunteer Applications</h1>
    <application-list :applications="this.$store.state.applications" />
    <user-list :users="this.$store.state.users" />
  </div>
</template>

<script>
import ApplicationList from "../components/ApplicationList.vue";
import UserList from "../components/ListOfUsers.vue";
import VolunteerService from "../services/VolunteerService";
import AuthService from "../services/AuthService";

export default {
  components: {
    ApplicationList,
    UserList,

  },
  
  data() {
    return {
      applications: [],
      users: [],
      isLoading: true,
      name:''
    };
  },

  created() {
    VolunteerService.getApplications()
      .then((response) => {
        this.applications = response.data;
        this.$store.state.applications = response.data;
        //this.animals = result.data;
      })
      .catch((error) => {
        console.log("There was an error");
      });
    AuthService.getUsers()
      .then((response) => {
        this.users = response.data;
        this.$store.state.users = response.data;
        this.isLoading = false;
      })
      .catch((error) => {
        console.log("There was an error #2");
      });
  },
  /*
  methods: {

  

    // getAnimals() { 
    //   animalServices.getAnimals()
    //     .then(response => { 
    //       this.animals = response.data;
    //       this.isLoading = false;
    //     })

    // }
  },
  */
  // created() {
  //   this.getAnimals();
  // }
};
</script>

<style scoped>
.home {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
  margin: 1rem 10%;
  background-color: var(--card-background);
  border-radius: 1rem;
  background-color: var(--card-background);
  padding:1rem;
  margin-top: 3rem;
}

#homeH1 {
  font-family: var(--font-h1);
  font-size: 3rem;
  color: var(--company-color-1);
}

#loadingDiv {
    background-color: var(--company-color-2);
    height: 100vh;
    width: 100vw;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    z-index: 10000;
    position: fixed;
    top: 0;
    left: 0;
}

  #loadingDiv img {
    width: 25%;
    height: 25%;
    object-fit: contain;
  }
  
input{
  justify-content: center;
  margin: 10px;
}
</style>

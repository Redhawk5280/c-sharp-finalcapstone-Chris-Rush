<template>
  <div id="loadingDiv" v-if="isLoading">
    <img src="../assets/loading-gif/loading-dog.gif"/>
  </div>
  <div class="home" v-else>
    <h1 id="homeH1">Volunteers</h1>
    <application-list 
    :applications="this.$store.state.applications" 
    />
  </div>
</template>

<script>
import ApplicationList from "../components/ApplicationList.vue";
import VolunteerService from "../services/VolunteerService";





export default {
  components: {
    ApplicationList,
  },
  data() {

    return {
      applications: [],
      isLoading: true,
    };
  },
  computed: {
  },
  created() {
    VolunteerService.getApplications().then(response => {
      this.applications = response.data;
      this.$store.state.applications = response.data;
      this.isLoading = false;
      //this.animals = result.data;
    }).catch(error => {
      console.log("There was an error");
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
    margin: 0 10%;
  }

  #homeH1 {
    font-family: var(--font-h1);
    font-size: 3rem;
    color: var(--company-color-1);
  }

  #loadingDiv img {
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


</style>

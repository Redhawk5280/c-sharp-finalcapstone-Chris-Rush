<template>
  <div id="loadingDiv" v-if="isLoading">
    <img src="../assets/loading-gif/loading-dog.gif"/>
  </div>
  <div class="home" v-else>
    <h1 id="homeH1">Welcome to Paw Prints Pet Rescue</h1>
    <animal-list 
      :animals="this.$store.state.animals" 
    />
  </div>
</template>

<script>
import AnimalList from "../components/AnimalList.vue";
import animalService from "../services/AnimalService";

// import photo1 from "../assets/PetPics - Copy/20231122_193301.jpg";
// import photo2 from "../assets/PetPics - Copy/1000003659.jpg";
// import photo3 from "../assets/PetPics - Copy/1000008441 - Copy.jpg";
// import photo4 from "../assets/PetPics - Copy/1000008441.jpg";





export default {
  components: {
    AnimalList,
  },
  data() {

    return {
      animals: [],
      isLoading: true,
      photos: [],

      hasLoggedIn: false,
    };
  },
  computed: {
    /*
    animalPhotos() {
      return this.$store.getters.animalPhotos;
    }
    */
  },
  created() {
    animalService.getAnimals().then(response => {
      this.animals = response.data;
      this.$store.state.animals = response.data;
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
    background-color: var(--card-background);
    padding:1rem;
    border-radius: 1rem;
    margin-top: 3rem;
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

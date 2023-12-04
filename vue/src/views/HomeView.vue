<template>
  <div class="home">
    <h1>Welcome to Paw Prints Pet Rescue</h1>
    <animal-list 
      :animals="this.$store.state.animals" 
    />

    <image-grid-display v-bind:images="images"></image-grid-display>
  </div>
</template>

<script>
import AnimalList from "../components/AnimalList.vue";
import animalService from "../services/AnimalService";

import ImageGridDisplay from '../components/ImageGridDisplay.vue';
import imageService from '../services/ImageService.js';

// import photo1 from "../assets/PetPics - Copy/20231122_193301.jpg";
// import photo2 from "../assets/PetPics - Copy/1000003659.jpg";
// import photo3 from "../assets/PetPics - Copy/1000008441 - Copy.jpg";
// import photo4 from "../assets/PetPics - Copy/1000008441.jpg";





export default {
  components: {
    AnimalList,
    ImageGridDisplay
  },
  data() {

    return {
      //animals: [],
      isLoading: false,
      //photos: []
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
    animalService.getAnimals().then(result => {
      this.$store.state.animals = result.data;
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
  }
</style>

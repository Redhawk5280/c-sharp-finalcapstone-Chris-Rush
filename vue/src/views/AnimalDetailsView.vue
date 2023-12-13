<template>
  <div id="loadingDiv" v-if="isLoading">
    <img src="../assets/loading-gif/loading-dog.gif"/>
  </div>
  <section id="detailsView">
    <animal-details v-bind:animal="animal" v-if="isLoading == false"/>
  </section>
</template>

<script>
import AnimalDetails from "../components/AnimalDetail.vue";
import animalService from "../services/AnimalService"; // Ensure this import is correct

export default {
  components: {
    AnimalDetails,
  },
  data() {
    return {
      isLoading: true,
      animal: {
        photos: [],
      },
    };
  },
  created() {
    animalService.getAnimal(this.$route.params.id).then(response => {
      this.animal = response.data;
      this.isLoading = false;
      console.log(this.$route.params.id);
    }).catch(error => {
      console.log("There was an error");
    });
  },
  methods: {
    goToHome() {
      this.$router.push({ name: 'home' });
    }
  }
};
</script>

<style scoped>
  #detailsView {
    display: flex;
    flex-direction: column;
    align-items:center;
    justify-content: center;
    font-family: var(--card-body-font);
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
  
</style>

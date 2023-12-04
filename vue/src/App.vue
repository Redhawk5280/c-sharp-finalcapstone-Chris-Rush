<template>
  <div id="capstone-app">
    <div id="nav">
      <div>
        <img src="\paw-prints-pet-rescue-logo-zip-file\png\logo-color.png" alt="" id="logoImg">
      </div>
      <div class="nav-links">
        <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
        <router-link v-bind:to="{ name: 'volunteerForm' }">Volunteer</router-link>&nbsp;|&nbsp;

        <router-link v-bind:to="{ name: 'login' }" >Login</router-link>&nbsp;|&nbsp;
        <router-link v-bind:to="{name: 'register'}" >Register</router-link>&nbsp;|&nbsp;
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      </div>

      
    </div>
    <router-view />
  </div>
</template>

<script>
import animalService from "./services/AnimalService";
export default {
  mounted() {
    animalService.getAnimals().then(response => {
      this.animals = response.data;
      this.$store.state.animals = response.data;
      //this.animals = result.data;
    }).catch(error => {
      console.log("There was an error");
    });
  },
};
</script>

<style scoped>
  #nav{
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
  }

  #logoImg {
    height: auto;
    width: 240px;
  }
</style>



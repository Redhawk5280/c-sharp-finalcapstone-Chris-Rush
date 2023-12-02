<template>
  <section class="animalCard" v-on:click="goToDetails(animal.id)">
    <img src="../assets/PetPics - Copy/20231122_193301.jpg"/>
    <h1>Name: </h1>
    <h2>Age:  </h2>
    <p>Special Needs: </p>
  </section>
</template>

<script>


export default {
  props: [
    'animal'
  ],
  methods: {
    goToDetails(id) { 
      this.$router.push({
        name: 'animalDetails',
        params: {id: id}
      })
    }
  }
}
</script>

<style scoped>
  .animalCard {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    border: 1px solid green;
    border-radius: 1rem;
    cursor: pointer;
  }
  .animalCard img{
    max-width: 100%;
    border-radius: 1rem;
  }

  .animalCard h1,h2,p{
    margin: 0;
    padding: 0;
  }
</style>
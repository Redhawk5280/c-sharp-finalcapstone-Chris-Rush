<template>
  <section 
    class="animalCard" 
    v-bind:class="{specialNeeds: animal.specialNeeds}"
  >
    <img :src="animal.photoSrc"/>
    <h1>Name: {{animal.name}}</h1>
    <h2>Age:  {{animal.age}}</h2>
  </section>
</template>

<script>


export default {
  props: [
    'animal'
  ],
  methods: {
  }
}
</script>

<style scoped>
  .animalCard {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    border-radius: 1rem;
    cursor: pointer;
    box-shadow: var(--generic-shadow);
    
  }
  .animalCard img{
    width: 100%; 
    height: 200px; 
    object-fit: cover; 
    max-height: 200px; 
    object-position: center;
    object-fit: contain;
    border-radius: 1rem;
  }

  .animalCard h1,h2,p{
    margin: 0;
    padding: 0;
  }

  .specialNeeds {
    background-color: orange;
  }
</style>
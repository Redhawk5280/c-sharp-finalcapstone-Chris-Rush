<template>
  <section 
    class="animalCard" 
    v-bind:class="{specialMedicalNeeds: animal.specialNeeds}"
  >
    <img :src="profilePhoto"/>
    <h1>{{animal.name}}</h1>
    <h2>
      {{ageText}}
    </h2>
  </section>
</template>

<script>


export default {
  props: [
    'animal'
  ],
  methods: {
    
  },
  computed: { 
    ageText: function() {
      if (this.animal.age === 1) {
        return `${this.animal.age} year old`;
      } else {
        return `${this.animal.age} years old`;
      }
    },
    profilePhoto: function() {
      if (this.animal.photos && this.animal.photos.length > 0){
        return this.animal.photos[0].imageString;
      }
      else{
        return "";
      }
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
    border-radius: 1rem;
    cursor: pointer;
    box-shadow: var(--generic-shadow);
    background-color: var(--company-color-1);
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
    font-family: var(--card-body-font);
    color: var(--company-color-2);
  }

  .specialMedicalNeeds {
    background-color: orange;
  }
</style>
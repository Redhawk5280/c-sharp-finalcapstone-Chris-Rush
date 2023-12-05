<template>
  <section 
    class="animalCard" 
    v-bind:class="{specialMedicalNeeds: animal.specialNeeds}"
  >
    <img :src="profilePhoto" id="animalPic"/>
    <div id="curve">
      <h1 id="animalName">{{animal.name}}</h1>
      <h2>
        {{ageText}}
      </h2>
    </div>
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
    overflow: none;
    position: relative;
    height: 400px;
    padding-bottom: 1rem;
    border-radius: 1rem;
  }

  .animalCard img{
    width: 100%; 
    height: 100%; 
    object-fit: cover; 
    object-position: center;
    border-radius: 1rem 1rem 0 0;
  }

  #curve {
    position: absolute;
    bottom: -1px; 
    width: 100%;
    height: 3rem; 
    background-color: var(--company-color-1);
    border-radius:  0 0 1rem 1rem; 
    padding: 1rem 0;
  }

  #curve::before {
    content: ''; /* Necessary for a pseudo-element */
    position: absolute; /* Position it absolutely within #curve */
    bottom: 100%; /* Position it at the bottom of the #curve */
    left: 0;
    width: 100%;
    height: 25%; /* Same height as the #curve to cover the image's bottom part */
    border-radius: 60% 60% 0 0; /* This creates an elliptical curve */
    background-color: var(--company-color-1); /* The background color of the curve */
    z-index: 10; /* Ensure it sits above the image */
    overflow: hidden;
  }



  .animalCard h1,h2,p{
    margin: 0;
    padding: 0;
    font-family: var(--card-body-font);
    color: var(--company-color-2);
    max-width: 100%;
  }

  .specialMedicalNeeds {
    background-color: orange;
  }
</style>
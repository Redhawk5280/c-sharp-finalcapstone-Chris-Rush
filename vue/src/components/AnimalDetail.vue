<template>
  <div class="details">
    <div id="imageContainer">
    <img :src="animal.photos[0].imageString" alt="">
  </div>
    <h1>A little about me...</h1>
    <p>Name: {{ this.animal.name }}</p>
    <p>{{ this.animal.aboutMe }}</p>
    <p>Age: {{ this.ageText }}</p>
    <p>Breed: {{ this.animal.breed }}</p>
    <p>Do I have medical needs?
    <br> {{ this.medicalNeeds}}</p>
    <p>Sex: {{ this.animal.sex }}</p>
    <p>Weight: {{ this.animal.weight }} lbs</p>
    <p>iS gOoD bOy/GiRl: {{ this.isGood }}</p>

  </div>
</template>


<script>

export default {
  props: ['animal'],
  computed: { 
    ageText: function() {
      if (this.animal.age === 1) {
        return `${this.animal.age} year old`;
      } else {
        return `${this.animal.age} years old`;
      }
    },
    photoPath() {
      if(this.animal && this.animal.photos){
        return this.animal.photos[0].imageString;
      } else{
        return "";
      }
    },
    isGood: function(value){
      if(this.animal.isGood=== true){
        return "I sure am!"
      }else{
        return "no :("
      }
    },
    medicalNeeds: function(value){
      if(this.animal.medicalNeeds=== true){
        return "I have some additional medical baggage"
      }else{
        return "no :("
      }
    }
  }
}
</script>

<style scoped>
  .details{
    text-align: left;
    font-family: var(--card-body-font);
    font-weight: bold;
    background-color: rgb(211, 195, 144);
    padding:1rem;
    border-radius: 1rem;
    box-shadow:var(--generic-shadow)
    
  }

  img {
    width: 300px;
    height:  300px;
    object-fit: cover; 
    border-radius: 1rem;


  }
  #imageContainer{
    justify-content: center;
    display:flex;
  }
  h1{
    display:flex;
    justify-content: center;
  }

</style>
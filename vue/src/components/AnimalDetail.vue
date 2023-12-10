<template>
  <button @click='this.editForm = !this.editForm'>Edit</button>
  <div class="detailForm" v-if="this.editForm">
    <form v-on:submit.prevent="this.changeAnimal(this.newAnimal)">
      <img 
        v-for="photo in this.newAnimal.photos"
        v-bind:key="photo"
        v-bind:photo="photo" 
        v-bind:src="photo.imageString"
      />
      <div class="form-input-group">
        <label for="name">Name: </label>
        <input id="name" v-model="this.newAnimal.name" />
      </div>
      <div class="form-input-group">
        <label for="age">Age: </label>
        <input type="number" min="0" id="password" v-model="this.newAnimal.age" required />
      </div>
      <div class="form-input-group">
        <label for="breed">Breed: </label>
        <input type="text" id="breed" v-model="this.newAnimal.breed" required />
      </div>
      <div class="form-input-group">
        <label for="species">Species: </label>
        <select v-model="this.newAnimal.species" required>
          <option disabled value="">Please Select One</option>
          <option>Dog</option>
          <option>Cat</option>
          <option>Guinea Pig</option>
        </select>
      </div>
      <div class="form-input-group">
        <label for="medicalNeeds">Medical Needs? </label>
        <input v-model="this.newAnimal.medicalNeeds" type="checkbox" />
      </div>
      <div class="form-input-group">
        <label for="color">Color: </label>
        <input type="text" id="color" v-model="this.newAnimal.color" required />
      </div>
      <div class="form-input-group">
        <label for="isAdopted">Is Adopted? </label>
        <input v-model="this.newAnimal.isAdopted" type="checkbox" />
      </div>
      <div class="form-input-group">
        <label for="ownerName">Owner Name? </label>
        <input type="text" id="ownerName" v-model="this.newAnimal.ownerName"  />
      </div>
      <div class="form-input-group">
        <label for="sex">Sex </label>
        <select v-model="this.newAnimal.sex" required>
          <option disabled value="">Please Select One</option>
          <option>Male</option>
          <option>Female</option>
        </select>
      </div>
      <div class="form-input-group">
        <label for="weight">Weight </label>
        <input type="number" min="0" id="weight" v-model="this.newAnimal.weight" required />
      </div>
      <div id="aboutMeContainer" class="form-input-group">
        <label for="aboutMe">About Me: </label>
        <textarea id="aboutMe" v-model="this.newAnimal.aboutMe" required />
      </div>
      

      <div class="form-input-group">
        <label for="isGood">Is Good Boy/Girl? </label>
        <input type="checkbox" id="isGood" v-model="this.newAnimal.isGood" required />
      </div>
      <div id="buttonContainer">
        <button type="submit">Edit Animal</button>
      </div>
    </form>
  </div>
  <div class="details" v-else>
    <div id="imageContainer">
    <img :src="animal.photos[0].imageString" alt="">
  </div>
    <h1>A little about me...</h1>
    <p>Name: {{ this.animal.name }}</p>
    <p>Description: {{ this.animal.aboutMe }}</p>
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
import AnimalService from "../services/AnimalService";

export default {
  props: ['animal'],
  data() { 
    return {
      newAnimal: this.animal,
      editForm: false,
    }
  },
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
        return "no"
      }
    },
    medicalNeeds: function(value){
      if(this.animal.medicalNeeds=== true){
        return "I have some additional medical baggage"
      }else{
        return "Nope"
      }
    },
  },
  methods: {
    changeAnimal: function(animalToEdit) { 
      console.log("the animal to edit?")
      console.log(animalToEdit)
        AnimalService.update(animalToEdit.id,animalToEdit)
          .then(response => {
            this.$router.push({'name': 'animals'})
            alert(`changed details of ${animalToEdit.name}!`)
            this.$store.commit('EDIT_ANIMAL', animalToEdit)
        })
        .catch(error=>{
          alert("We're sorry, animal cannot be changed")
        })
    },
    edit() { 
      console.log("clicked");
      console.log(this.editForm);
      this.editForm = !this.editForm
    },
  }
}
</script>

<style scoped>

/* */


  h1 {
  text-align:center;
}

.form-group {
  margin-bottom: 15px;
  font-family: var(--card-body-font);
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bolder;
  font-family: var(--card-body-font);
}

input {
  width: 96%;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-family: var(--card-body-font);
}
textarea {
  width: 96%;
  height: 50px;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-family: var(--card-body-font);
}

select, option {
  font-family: var(--card-body-font);
}

button[type="submit"] {
  background-color: #4CAF50;
  color: white;
  padding: 10px 15px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  width: 100%;
}

button[type="submit"]:hover {
  background-color: #45a049;
}

/* */

  .detailForm{
    max-width: 400px;
  margin: 1rem auto;
  padding: 20px;
  box-shadow: var(--generic-shadow);
  border-radius: 1rem;
  }
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
<template>
  <section id="addAnimalContainer">
    <image-upload-form/>
    <form v-on:submit.prevent="addAnimal(animal)">
      <div class="form-input-group">
        <label for="name">Name: </label>
        <input type="text" id="name" v-model="animal.name" required autofocus />
      </div>
      <div class="form-input-group">
        <label for="age">Age: </label>
        <input type="number" min="0" id="password" v-model="animal.age" required />
      </div>
      <div class="form-input-group">
        <label for="breed">Breed: </label>
        <input type="text" id="breed" v-model="animal.breed" required />
      </div>
      <div class="form-input-group">
        <label for="species">Species: </label>
        <select v-model="animal.species" required>
          <option disabled value="">Please Select One</option>
          <option>Dog</option>
          <option>Cat</option>
          <option>Guinea Pig</option>
        </select>
      </div>
      <div class="form-input-group">
        <label for="medicalNeeds">Medical Needs? </label>
        <input v-model="animal.medicalNeeds" type="checkbox" required/>
      </div>
      <div class="form-input-group">
        <label for="color">Color: </label>
        <input type="text" id="color" v-model="animal.color" required />
      </div>
      <div class="form-input-group">
        <label for="isAdopted">Is Adopted? </label>
        <input v-model="animal.isAdopted" type="checkbox" required/>
      </div>
      <div class="form-input-group">
        <label for="ownerName">Owner Name? </label>
        <input type="text" id="ownerName" v-model="animal.ownerName" required />
      </div>
      <div class="form-input-group">
        <label for="sex">Sex </label>
        <select v-model="animal.sex" required>
          <option disabled value="">Please Select One</option>
          <option>Male</option>
          <option>Female</option>
        </select>
      </div>
      <div class="form-input-group">
        <label for="weight">Weight </label>
        <input type="number" min="0" id="weight" v-model="animal.weight" required />
      </div>
      <div id="aboutMeContainer" class="form-input-group">
        <label for="aboutMe">About Me: </label>
        <textarea id="aboutMe" v-model="animal.aboutMe" required />
      </div>
      

      <div class="form-input-group">
        <label for="isGood">Is Good Boy/Girl? </label>
        <input type="checkbox" id="isGood" v-model="animal.isGood" required />
      </div>
      <div id="buttonContainer">
        <button type="submit">Add Animal</button>
      </div>
    </form>

  </section>
</template>

<script>
import ImageUploadForm from '../components/ImageUploadForm.vue';
import AnimalService from '../services/AnimalService';

export default {
  components: {
    ImageUploadForm,
  },
  data() { 
    return {
      animal: {},
    }
  },
  methods: {
    addAnimal(animal) { 
      console.log("the animal?")
      console.log(animal)
      AnimalService.addAnimal(this.animal).then(response=>
      {
        this.$router.push({'name': 'animals'})
        alert("Thank you for adding an animal!")
        this.$store.commit('ADD_APPLICATION', this.animal)
      })
        .catch(error=>{
          alert("We're sorry, animal cannot be added")
          this.animal={}
        })
    }
  }
}

</script>

<style scoped>

  #addAnimalContainer {
    max-width: 400px;
    margin: 3rem auto;
    padding: 20px;
    box-shadow: var(--generic-shadow);
    border-radius: 1rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }

  #aboutMeContainer {
    display: flex;
    align-items: center;
  }

  #buttonContainer {
    width: 100%;
    display: flex;
    justify-content: center;
  }
  button[type="submit"] {
    border-radius: 1rem;
    padding: 8px 16px;
    border: none;
    background-color: green;
    box-shadow: var(--general-shadow);
  }
</style>
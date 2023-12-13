<template>
  <div v-bind:class="{ hidden: successMessage == false }">
    <div class="success">
      <h1>Profile Updated!</h1>
      <p>Thank you!</p>
      <button :onclick="closePopup">Back</button>
    </div>
  </div>



  <div v-bind:class="{ hidden: successMessage || errorMessage }">
    
    <div v-if="this.role" class="buttonContainer">
      <button v-if="this.editForm == false" class="editButton" @click='this.editForm = true'>Edit</button>
      <button v-else class="closeButton" @click='closeEditForm'>Cancel</button>
    </div>
    

    <div class="detailForm" v-if="this.editForm && this.role">
      


      <form v-on:submit.prevent="this.changeAnimal(newAnimal)">
        <form @submit.prevent="onSubmit">

          <p>Select an image to upload. {{ this.x }}</p>
          <input v-on:change="loadImage" type="file" accept="image/*">

          <div id="edit" v-for="photo in newAnimal.photos" v-bind:key="photo.imageString">
            <img class="image-preview" v-bind:src="photo.imageString" />
            <button v-on:click="deletePhoto(newAnimal.photos.indexOf(photo))">Delete</button>
            
          </div>
          
          
        </form>
        <div class="form-input-group">
          <label for="name">Name: </label>
          <input id="name" v-model="newAnimal.name" />
        </div>
        <div class="form-input-group">
          <label for="age">Age: </label>
          <input type="number" min="0" id="password" v-model="newAnimal.age" required />
        </div>
        <div class="form-input-group">
          <label for="breed">Breed: </label>
          <input type="text" id="breed" v-model="newAnimal.breed" required />
        </div>
        <div class="form-input-group">
          <label for="species">Species: </label>
          <select v-model="newAnimal.species" required>
            <option disabled value="">Please Select One</option>
            <option>Dog</option>
            <option>Cat</option>
            <option>Guinea Pig</option>
          </select>
        </div>
        <div class="form-input-group">
          <label for="medicalNeeds">Medical Needs? </label>
          <input v-model="newAnimal.medicalNeeds" type="checkbox" />
        </div>
        <div class="form-input-group">
          <label for="color">Color: </label>
          <input type="text" id="color" v-model="newAnimal.color" required />
        </div>
        <div class="form-input-group">
          <label for="isAdopted">Is Adopted? </label>
          <input v-model="newAnimal.isAdopted" type="checkbox" />
        </div>
        <div class="form-input-group">
          <label for="ownerName">Owner Name? </label>
          <input type="text" id="ownerName" v-model="newAnimal.ownerName" />
        </div>
        <div class="form-input-group">
          <label for="sex">Sex </label>
          <select v-model="newAnimal.sex" required>
            <option disabled value="">Please Select One</option>
            <option>Male</option>
            <option>Female</option>
          </select>
        </div>
        <div class="form-input-group">
          <label for="weight">Weight </label>
          <input type="number" min="0" id="weight" v-model="newAnimal.weight" required />
        </div>
        <div id="aboutMeContainer" class="form-input-group">
          <label for="aboutMe">About Me: </label>
          <textarea id="aboutMe" v-model="newAnimal.aboutMe" required />
        </div>


        <div class="form-input-group">
          <label for="isGood">Is Good Boy/Girl? </label>
          <input type="checkbox" id="isGood" v-model="newAnimal.isGood" required />
        </div>
        <div class="buttonContainer">
          <button type="submit">Save Changes</button>
        </div>
      </form>
    </div>

    


    <div class="details" v-else>
      <div id="imageContainer">
        <img v-for="photo in this.animal.photos" v-bind:key="photo" v-bind:photo="photo"
          v-bind:src="photo.imageString" />
      </div>

      <h1 v-if="animal.isAdopted">I Have Found My Furever Home!</h1>
      <h1 v-else>Hello New Friend!</h1>

      <h1>A little about me...</h1>
      <p>Name: {{ this.animal.name }}</p>
      <p>Age: {{ this.ageText }}</p>
      <p>Description: {{ this.animal.aboutMe }}</p>
      <p>Sex: {{ this.animal.sex }}</p>
      <p>Species: {{ this.animal.species }}</p>
      <p>Breed: {{ this.animal.breed }}</p>
      <p>Color: {{ this.animal.color }}</p>
      <p>Do I have medical needs?
        <br> {{ this.medicalNeeds }}
      </p>
      <p>Weight: {{ this.animal.weight }} lbs</p>

      <p>Is a good {{ this.animal.sex == "Male" ? "boy" : "girl" }}: {{ this.isGood }}</p>

    </div>
  </div>
</template>


<script>
import AnimalService from "../services/AnimalService";

export default {
  props: ['animal'],
  data() {
    return {
      //startingAnimal: Object,
      newAnimal: this.animal,
      editForm: false,
      successMessage: false,
      errorMessage: false,
    }
  },
  computed: {
    ageText: function () {
      if (this.animal.age === 1) {
        return `${this.animal.age} year old`;
      } else {
        return `${this.animal.age} years old`;
      }
    },
    photoPath() {
      if (this.animal && this.animal.photos) {
        return this.animal.photos[0].imageString;
      } else {
        return "";
      }
    },
    isGood: function (value) {
      if (this.animal.isGood === true) {
        return "I sure am!"
      } else {
        return "no"
      }
    },
    medicalNeeds: function (value) {
      if (this.animal.medicalNeeds === true) {
        return "I have some additional medical baggage"
      } else {
        return "Nope"
      }
    },
    role: function () {
      if (this.$store.state.user.role === "admin" || this.$store.state.user.role === "user") {
        return true;
      }
      else {
        return false;
      }
    }
  },
  methods: {
    closePopup() {
      this.successMessage = false;
      this.errorMessage = false;
      this.editForm = false;
    },
    closeEditForm(){
      this.$router.go();
    },
    changeAnimal: function (animalToEdit) {
      console.log("the animal to edit?")
      console.log(animalToEdit)
      AnimalService.update(animalToEdit.id, animalToEdit)
        .then(response => {
          //this.$toast.open(`changed details of ${animalToEdit.name}!`)
          this.$store.commit('EDIT_ANIMAL', animalToEdit)
          //this.$router.go();
          //this.$router.push({"name": "volunteer-success"});
          this.successMessage = true;
        })
        .catch(error => {
          alert("an error occurred");
        })
    },
    edit() {
      console.log("clicked");
      console.log(this.editForm);
      this.editForm = !this.editForm
    },
    loadImage(e) {
      this.imageFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = (evt) => {
        this.newAnimal.photos.push(
          {
            "imageString": evt.target.result,
            "animalId": -1,
            "imageId": -1
          });
      };
      reader.readAsDataURL(this.imageFile);
    },
    deletePhoto(id) {
      this.newAnimal.photos.splice(id, 1)
    }
  },
  created() {
    this.newAnimal = this.animal;
  }
}
</script>

<style scoped>
/* */

#imageContainer {
  display: flex;
  width: 100%;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.hidden {
  display: none;
}

.success {
  background-color: var(--card-background);
  width: 50%;
  min-width: 250px;
  min-height: 100px;
  margin: auto;
  padding: 1rem;
  border-radius: 1rem;
  margin-top: 3rem;
  display: flex;
  flex-direction: column;
  align-items: center;

}

h1 {
  text-align: center;
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

select,
option {
  font-family: var(--card-body-font);
}

.buttonContainer {
  margin: auto;
  display: flex;
  align-items: center;
  margin: 1rem;
}

button {
  color: var(--company-color-1);
  border: none;
  border-radius: 0.5rem;
  width: 6rem;
  height: 2rem;
  margin: auto;
}
/*
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
  cursor: pointer;
}*/

#edit {
  display: flex;
  flex-direction: column;
  justify-content: center;


}

#edit button {
  border-radius: 1rem;
  background-color: red;
  border: none;
  margin: auto;
  padding: 0.5rem 1rem;
  margin-bottom: 1rem;
  font-family: var(--card-body-font);
  font-weight: bold;
  color: white;
  cursor: pointer;

}

/* */

.detailForm {
  max-width: 400px;
  margin: 1rem auto;
  padding: 20px;
  box-shadow: var(--generic-shadow);
  border-radius: 1rem;
  background-color: var(--card-background);
}

.details {
  text-align: left;
  font-family: var(--card-body-font);
  font-weight: bold;
  background-color: var(--card-background);
  padding: 1rem;
  border-radius: 1rem;
  box-shadow: var(--generic-shadow)
}

img {
  width: 300px;
  height: 300px;
  object-fit: cover;
  border-radius: 1rem;
  margin-bottom: 1rem;
  border-radius: 1rem;


}

#imageContainer {
  justify-content: center;
  display: flex;
}

h1 {
  display: flex;
  justify-content: center;
}
</style>
<template>
  <div id="filter">
    <div id="dropdown">
      <div class="filter">
        <label for="animalFilter">Filter by Animal Type:</label>
      <select id="animalFilter" v-model="species">
        <option value="">All Animals</option>
        <option value="Dog">Dogs</option>
        <option value="Cat">Cats</option>
        <option value="Guinea Pig">Guinea Pigs</option>
      </select>


      </div>
      <div class="filter">
        <label for="sexFilter">Filter by Animal Sex:</label>
        <select id="sexFilter" v-model="sex">
          <option value="">All</option>
          <option value="Male">Male</option>
          <option value="Female">Female</option>
        </select>


      </div>
      <div class="filter">
        <label for="medicalFilter">Filter by Medical Needs:</label>
        <select id="medicalFilter" v-model="medicalNeeds">
          <option value="">All</option>
          <option value="0">No</option>
          <option value="1">Yes</option>
        </select>


      </div>


    </div>
  <div id="type">
    <input type="text" v-model="name" placeholder="Search animal name..." />
    <input type="text" v-model="color" placeholder="Search animal color..." />
    <input type="text" v-model="breed" placeholder="Search animal breed..." />
    <input type="number" v-model="age" placeholder="Search by animal age..." />
    <input type="text" v-model="color" placeholder="Search animal color..." />


  </div>

  </div>

  <div class="animalList">
      <animal-card 
        v-for="animal in filterAnimals" 
        v-bind:key="animal.id"
        v-bind:animal="animal" 
        v-on:click="goToDetails(animal.id)"
        class="animalCard"
      />
  </div>
</template>

<script>

  import AnimalCard from "../components/AnimalCard.vue"
  import animalService from "../services/AnimalService";
export default {
      props: {
        animals: Array,
      },    
      components: {
        AnimalCard,
      },
      data() { 
        return {
          isLoading: false,
          species: '',
          color:'',
          breed:'',
          name:'',
          age: '',
          sex:'',
          medicalNeeds:'',
        }
    },
    methods: {
      goToDetails(id) { 
        this.$router.push({ name: 'animalDetails', params: {id: id} })
      }
    },
      created() { 
        // TODO: uncomment this eventually
          // this.isLoading = true;
          // animalService.getAnimals()
          //   .then(response => { 
          //     this.animals = response.data;
          //     this.isLoading = false;
          //   })
          //   .catch(error => {
          //     console.error("Error fetching animals:", error);
          //     this.isLoading = false;
          //   });
      },
      computed:{
        filterAnimals(){
        if(this.species == '' && this.color =='' && this.breed == '' && this.sex =='' && this.medicalNeeds ==''){
        return this.animals;
        }
      else{
        return this.animals.filter(animal=>{
          return animal.species == this.species || this.species == '';


        }).filter(animal=>{
          return animal.color.toLowerCase().includes(this.color.toLowerCase()) || this.color == '';
        }).filter(animal=>{
          return animal.breed.toLowerCase().includes(this.breed.toLowerCase()) || this.breed == '';
        }).filter(animal=>{
          return animal.name.toLowerCase().includes(this.name.toLowerCase()) || this.name == '';
        }).filter(animal=>{
          return animal.age <= this.age || this.age ==''
        }).filter(animal=>{
          return animal.sex == this.sex || this.sex ==''
        }).filter(animal=>{
          return animal.medicalNeeds == this.medicalNeeds || this.medicalNeeds ==''
        })

      }
    
      },
      }
  }
</script>

<style scoped>
  .animalList {
    height: 100%;
    width: 100%;
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: 1fr;
    grid-gap: 3rem;
    place-items: center;
    margin: auto;
    background-color: var(--card-background);
    padding:1rem;
    border-radius: 1rem;
    box-sizing: border-box;
  }
  #dropdown{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    font-family: var(--card-body-font);
    font-weight: bold;


    
  }
  select{
    margin-left: 4px;
  }
  .filter{
    margin: 10px;
  }
  input{
   margin: 10px;
  }
  #animalCardContainer{
    display: flex;
    justify-content: center;
  }

  .animalList .animalCard{
  }

  @media only screen and (max-width: 639px) {
    .animalList {
      grid-template-columns: 1fr;
    }
  }

  @media only screen and (min-width: 640px) and (max-width: 1024px) {
    /* Styles for landscape smartphones and tablets in portrait mode */
    .animalList {
      grid-template-columns: repeat(2, 1fr);
    }
  }

  @media only screen and (min-width: 1024px) and (max-width: 1439px) {
    /* Styles for larger devices like tablets in landscape and smaller desktops */
    .animalList {
      grid-template-columns: repeat(3, 1fr);
    }
  }

  @media only screen and (min-width: 1440px) {
    /* Styles for extra large devices like large desktops and TVs */
    .animalList {
      grid-template-columns: repeat(3, 1fr);
    }
  }

</style>
<template> 
<div id="home">
    <div id="homeImg">
        <img  src="../assets/building/wow.jpg" alt="building">
    </div>
    <div>  
        <h1>About Us</h1>
        <div id="paragraph">
            <p id="p1"> 
                &nbsp;&nbsp;&nbsp;&nbsp;Welcome to Paw Prints Pet Rescue, where every paw print tells a story of hope and second chances! Our journey started in the heart of Cleveland, Ohio, a city pulsating with love for our furry friends. Established in 2010, Paw Prints Pet Rescue was born out of a shared passion for creating a haven where wagging tails, gentle purrs, and happy squeaks harmonize into a symphony of love.
            </p>
            <p id="p2">

                &nbsp;&nbsp;&nbsp;&nbsp;Dogs, cats, and guinea pigs, oh my! Paw Prints Pet Rescue is a haven for all shapes and sizes of furry companions. From energetic pups ready for a game of fetch to sophisticated felines with a penchant for purring conversations, and the adorable guinea pigs who bring a touch of whimsy to our rescue family, we welcome them all with open arms and ample belly rubs.
                Located in the heart of Cleveland, our rescue center is not just a place; it's a warm embrace for pets seeking a second chance and for humans eager to share their lives with a furry friend. Join us in our mission to turn every paw print into a tale of joy and a journey of love at Paw Prints Pet Rescue!
            </p>
        </div>
    </div>
    <div id="donations">
        <h1>Want to help us out?</h1>
        
            <p>Check out <span> <a target="_blank" href="https://www.amazon.com/hz/wishlist/ls/NUYRW25HE62W?ref_=wl_share">Our Wishlist</a></span></p>
            <p id="amazon">
                &nbsp;&nbsp;&nbsp;&nbsp;At Paw Prints Pet Rescue's Amazon Wishlist, your click transforms the lives of our rescues. Your support provides essential supplies, comfort, and love, ensuring our furry friends receive the care they need as they eagerly await their forever homes. Join us in creating happy tales of rescue and new beginnings!</p>

    </div>
    <div id="adoptedPets">
        <h1>Celebrate Our Adopted Friends!</h1>
        <!-- <div class="animalList">
            <animal-card 
                v-for="animal in adoptedAnimals" 
                v-bind:key="animal.id"
                v-bind:animal="animal" 
                class="animalCard"
            />
        </div> -->
        <animal-list 
            :animals="adoptedAnimals" 
        />
    </div>

</div>


</template>

<script>
import AuthService from "../services/AuthService";
import AnimalService from "../services/AnimalService";
import AnimalList from "../components/AnimalList.vue";



export default {
    components: {
        AnimalList,
    },

    data() { 
        return {
            newUser: this.$store.state.user,
            editForm: false,
            animals: this.$store.state.animals,
        }
    }, 
    methods: {

    },
    computed: {
        adoptedAnimals(){
            return this.$store.state.animals.filter(animal=>{
                return animal.isAdopted == true;
            })
      }
    
      },
    }
</script>


<style scoped > 
#home{
    font-family: var(--card-body-font);
    margin: 1.5rem 15%;
    display:flex;
    flex-direction: column;
    justify-content: center;
    background: var(--card-background);
    border-radius: 1rem;
    padding: 1rem;
}

#filter {
    display: none;
}



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
    height: 90%;
    width: 100%;
    padding-bottom:1rem;
    border-radius: 1rem;
    min-height: 350px;
  }

  #adoptedPets {

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    text-align: center;
    margin: 0 10%;
    background-color: var(--card-background);
    padding:1rem;
    border-radius: 1rem;
    margin-top: 3rem;
  }

#paragraph{
    font-family: var(--card-body-font);
    font-weight: bold;
}
#donations{
    text-align: center;
    font-weight: bold;
    
}
#amazon{
    text-align: left;
}

#homeImg{
    height: auto;
    width: 70%;
    margin: auto;
  
}
img{
    height: 100%;
    object-fit: fill;
    width:100%;
    border-radius: 1rem;
    box-shadow: var(--generic-shadow);

    
    
}
h1{
    text-align: center;
    text-decoration: underline;
    color: var(--company-color-1);
    object-fit: cover;
    border-radius: 1rem;
}

</style>
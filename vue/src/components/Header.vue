<template>
  <div id="imgContainer">
    <img
      src="/paw-prints-pet-rescue-logo-zip-file\png\logo-color.png"
      alt=""
      id="logoImg"
      width="350"
      height="350"
      style="width 350px; height: 350px"
    />
  </div>
  <div id="navContainer">
    <div id="nav">
      <div class="navDiv">
        <router-link class="nav-link" v-bind:to="{ name: 'home' }">Home</router-link>
      </div>
      <div class="navDiv">
        <router-link class="nav-link" v-bind:to="{name:'animals' }">Adopt Me!</router-link>
      </div>

      <div v-if="$store.state.token != ''" class="navDiv">
        <router-link class="nav-link" v-bind:to="{ name: 'addAnimal' }"
          >Add Animal</router-link
        >
      </div>
      <div v-else class="navDiv"> 
        <router-link class="nav-link" v-bind:to="{ name: 'volunteerForm' }"
          >Volunteer</router-link
        >
      </div>
      <div v-if="$store.state.token != ''" class="navDiv">
        <router-link 
          class="nav-link"
          v-bind:to="{name: 'directory'}"
        >
          Directory
        </router-link>
      </div>
      <div class="navDiv">
        <router-link
          class="nav-link"
          v-bind:to="{ name: 'login' }"
          v-if="$store.state.token == ''"
          >Login</router-link
        >
        <router-link class="nav-link" v-bind:to="{ name: 'logout' }" v-else
          >Logout</router-link
        >
      </div>
    </div>
  </div>
</template>

<script></script>

<style scoped>

:root {

  /* colors */
  --primary-color: #3498db;
  --secondary-color: #2ecc71;
  --accent-color: #9b59b6;
  --brand-orange: #f8961e;
  --brand-blue: #577590;
  --body-background: #bada55;

  --company-color-1: #395469;
  --company-color-2: #e79648;



  /* typography */
  --font-one: "Poppins", Montserrat;
  --font-h1: "Barrio";

  --card-body-font: "Cutive Mono";

  /* shadows */
  --generic-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;

}
.navDiv {
  padding: 0 1rem;
}

.navDiv:hover {
  background: rgba(0,0,0,0.2);
  border-radius: 1rem;
  cursor: pointer;
  color: inherit; 
}

#navContainer {
  display: flex;
  margin: 0 10%;
  align-items: center;
  justify-content: center;
  background: rgba(0,0,0,0.1);
  border-radius: 1rem;
}
#nav {
  width: 100%;
  padding: 0 1rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

#imgContainer {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  overflow-y: hidden;
  position: relative;
}

#imgContainer:after{
    content:'';
    width:100%;
    height:8px;
    position:absolute;
    bottom:0;
    left:0;
    background: var(--company-color-1);;
    border-radius:5px;
    margin: 1rem 0;
    }

#logoImg {
  width: 600px;
  height: 600px;
  margin-top: -80px;
  margin-bottom: -80px;
}
.nav-link {
  font-size: 2rem;
  padding: 0;
  text-align: center;
  text-decoration: none;
  font-family: var(--font-h1);
  color: inherit;
}




@media only screen and (max-width: 849px) {
    #nav {
      flex-direction: column;
    }
  }
</style>

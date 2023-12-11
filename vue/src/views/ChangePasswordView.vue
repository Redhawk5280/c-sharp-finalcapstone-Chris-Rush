<template>
  <div 
    id="firstLoginVolunteer" 
  >
    <h1>You have been approved. </h1>
    <h1>Please change your password here</h1>
    <form @submit.prevent="changePassword">
        <div class="form-input-group">
            <label for="password">Password</label>
            <input type="password" id="password" v-model="newPassword" required />
        </div>
        <div id="buttonContainer">
          <button type="submit">Change Password</button>
        </div>
    </form>
</div>
</template>

<script>
import AuthService from '../services/AuthService';

export default {

    data() { 
        return {
          newPassword: "",
        }
    }, 
    methods: {
        changePassword: function() { 
            AuthService.updateUser(this.$store.state.user.email, this.newPassword)
                .then(response => {
                    this.$router.push({ 'name': 'home' })
                    alert(`changed your password!`)
                    this.$store.commit("SET_USER", response.data);
                })
                .catch(error=>{
                    alert("We're sorry, password cannot be changed")
                })
        },
    },
}
</script>

<style scoped>
#firstLoginVolunteer{
    margin: 1.5rem 15%;
    text-align:center;
  }

  .form-input-group{
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  #buttonContainer {
    margin: 1rem 0;
  }

  button[type="submit"] {
  background-color: #4CAF50;
  color: white;
  padding: 10px 15px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  width: 25%;
}

button[type="submit"]:hover {
  background-color: #45a049;
}


</style>
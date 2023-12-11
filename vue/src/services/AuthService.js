import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },

  getUser() { 
    return axios.get('/login')
  },
  updateUser(email, newPassword){
    return axios.put(`/user/${email}`, {
      "email": email,
      "password": newPassword,
    })
  },
  getUsers(){
    return axios.get(`/user`)
  },
  deactivateUser(email){
    return axios.put(`user/deactivate/${email}`)
  }

}

import axios from 'axios';

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
  updateUser(user){
    return axios.put(`/user`)
  },
  getUsers(){
    return axios.get(`/user`)
  }

}

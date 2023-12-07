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

  getUsers() { 
    return axios.get('/users');
  },

  deactivateUser(id){ 
    return axios.put(`/users/deactivate/${id}`)
  }
}

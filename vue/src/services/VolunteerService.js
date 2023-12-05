import axios from 'axios';
const http = axios.create({
    baseURL:"https://localhost:44315"})
export default {

  getApplications() {
    return http.get('/volunteers/applications');
  },

  getApplicationById(id) {
    return http.get(`/volunteers/applications/${id}`);
  },
  addApplication(application){
    return http.post('/volunteers/applications', application)
  }
}

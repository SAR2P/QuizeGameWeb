import  Axios  from "axios";
// import { axios } from "axios";

export const BASE_URL = 'http://localhost:5100/'

export const ENDPOINTS = {
    participant: 'participants',
    question:'questions',
    getAnswers: 'questions/GetAnswers'

}

export const createApiEndPoint = endpoint => {
    let url = BASE_URL + 'api/' + endpoint + '/';
    return {
        fetch: () => Axios.get(url),
        fetchById: id => Axios.get(url + id),
        // post : newRecord => Axios.post(url, newRecord),
        post: newRecord => Axios.post(url, newRecord),
        put : (id,updatedRecord) => Axios.put(url + id, updatedRecord),
        delete : id => Axios.delete(url + id), 
    }
}



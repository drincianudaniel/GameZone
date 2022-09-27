import { ContainerClient } from "@azure/storage-blob";
import axios from "axios";

const defaultOptions = {
  baseURL: "https://localhost:7092/api",
  headers: {
    'Content-Type': 'application/json',
  },
};

let client = axios.create(defaultOptions);

// const client = (() => {
//   return axios.create({
//     baseURL: "https://localhost:7092/api",
//     headers: { Authorization: `Bearer ${localStorage.getItem("jwt")}` }
//   });
// })();

client.interceptors.request.use(function(config){
  const token = localStorage.getItem("jwt");
  config.headers.Authorization =  token ? `Bearer ${token}` : '';
    return config;
})
// const {token} = useUser();

// the request function which will destructure the response
const request = async function (options, store) {

  const onSuccess = function (response) {
    const {
      data: { message },
    } = response;
    return message;
  };

  const onError = function (error) {
    return Promise.reject(error.response);
  };

  return client(options)
};

export default request;

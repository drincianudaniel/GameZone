import axios from "axios";
import { Navigate } from "react-router";
import { useUser } from "../hooks/useUser";
import Error404Page from "../pages/Error404Page";
const client = (() => {
  return axios.create({
    baseURL: "https://localhost:7092/api",
  });
})();

// const {token} = useUser();

// the request function which will destructure the response
const request = async function (options, store) {
  // success handler

  const onSuccess = function (response) {
    const {
      data: { message },
    } = response;
    return message;
  };

  // error handler
  const onError = function (error) {
    return Promise.reject(error.response);
  };

  // adding success and error handlers to client
  return client(options).catch((err) => {
    if(err.response.status == 404){
      window.location.href = "/notfound";
      return;
    }
  });
};

export default request;

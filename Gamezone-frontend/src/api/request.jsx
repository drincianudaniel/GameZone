import axios from "axios";

const client = (() => {
  return axios.create({
    baseURL: "https://localhost:7092/api"
  });
})();

// the request function which will destructure the response
const request = async function (options, store) {
  // success handler
  const onSuccess = function (response) {
    const {
      data: { message }
    } = response;
    return message;
  };

  // error handler
  const onError = function (error) {
    return Promise.reject(error.response);
  };

  // adding success and error handlers to client
  return client(options);
};

export default request;
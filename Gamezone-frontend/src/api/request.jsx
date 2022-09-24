import axios from "axios";

const client = (() => {
  return axios.create({
    baseURL: "https://localhost:7092/api",
    // headers: { Authorization: `Bearer ${localStorage.getItem("jwt")}` }
  });
})();

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
  // .catch(err => onError(err))
  // .catch((err) => {
  //   if(err.response.status == 404){
  //     window.location.href = "/notfound";
  //     return;
  //   }
  // });
};

export default request;

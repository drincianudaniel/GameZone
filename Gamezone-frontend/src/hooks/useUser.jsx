import { createContext, useContext, useState, useEffect } from "react";
import jwt_decode from "jwt-decode";

const UserContext = createContext();

export function useUser() {
  return useContext(UserContext);
}

export function UserContextProvider({ children }) {
  const [user, setUser] = useState({
  });
  const [token, setToken] = useState([]);

  const value = {
    user,
    setUser,
    setToken,
  };

  useEffect(() => {
    console.log(user);

    if (localStorage.getItem("jwt")) {
      setUser(jwt_decode(localStorage.getItem("jwt")));
    }

  }, []);

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
}

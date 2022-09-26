import { createContext, useContext, useState, useEffect } from "react";
import jwt_decode from "jwt-decode";
import { useStateManager } from "react-select";

const UserContext = createContext();

export function useUser() {
  return useContext(UserContext);
}

export function UserContextProvider({ children }) {
  const [user, setUser] = useState({});
  const [loading, setLoading] = useState(true);
  const [token, setToken] = useState([]);

  const value = {
    user,
    loading,
    setLoading,
    setUser,
    setToken,
  };

  useEffect(() => {
    console.log(user);

    if (localStorage.getItem("jwt")) {
      setUser(jwt_decode(localStorage.getItem("jwt")));
      setLoading(false)
    }
  }, []);

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
}

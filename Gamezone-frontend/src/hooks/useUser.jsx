import { createContext, useContext, useState, useEffect } from "react";

const UserContext = createContext();

export function useUser() {
  return useContext(UserContext);
}

export function UserContextProvider({ children }) {
  const [user, setUser] = useState([]);
  const [token, setToken] = useState([]);

  const value = {
    user,
    setUser,
    setToken,
  };
 useEffect(() =>{
    console.log(user)
 })
  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
}

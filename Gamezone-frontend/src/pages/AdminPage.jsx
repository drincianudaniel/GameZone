import { useEffect } from "react";
import { Navigate, useNavigate } from "react-router";
import Header from "../components/Header";
import AddTabbedPanel from "../components/TabbedPanels/AddTabbedPanel";
import { useUser } from "../hooks/useUser";

function AdminPage() {

  const {user, loadingUser} = useUser();
  const history = useNavigate();

  const redirectToHome = () =>{
    history("/")
  }

  useEffect(()=>{

    if (loadingUser){
      return
    }
    
    if(user.IsLoggedIn !== true){
      redirectToHome()
    }

    if(user.IsAdmin === false){
      redirectToHome()
    }
  }, [user, user.IsLoggedIn, user.IsAdmin])

  return (
    <div>
      <Header />
      <AddTabbedPanel />
    </div>
  );
}

export default AdminPage;

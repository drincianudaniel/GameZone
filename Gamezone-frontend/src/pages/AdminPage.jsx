import { useEffect } from "react";
import { Navigate, useNavigate } from "react-router";
import Header from "../components/Header";
import AddTabbedPanel from "../components/TabbedPanels/AddTabbedPanel";
import { useUser } from "../hooks/useUser";

function AdminPage() {
  const {user} = useUser();
  const history = useNavigate();

  const redirectToHome = () =>{
    history("/")
  }

  useEffect(()=>{
    if(user.IsAdmin !== true){
      redirectToHome()
    }
  })

  return (
    <div>
      <Header />
      <AddTabbedPanel />
    </div>
  );
}

export default AdminPage;

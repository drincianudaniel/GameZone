import { Box } from "@mui/material";
import { useEffect } from "react";
import { useNavigate } from "react-router";
import Header from "../components/Header";
import AddTabbedPanel from "../components/TabbedPanels/AddTabbedPanel";
import { useUser } from "../hooks/useUser";

function AdminPage() {
  const { user, loadingUser } = useUser();
  const history = useNavigate();

  const redirectToHome = () => {
    history("/");
  };

  useEffect(() => {
    if (loadingUser) {
      return;
    }

    if (!user.IsLoggedIn) {
      redirectToHome();
    }

    if (user.IsAdmin === false) {
      redirectToHome();
    }
  }, [user, loadingUser]);

  return (
    <Box sx={{ height: "auto" }}>
      <Header />
      <AddTabbedPanel />
    </Box>
  );
}

export default AdminPage;

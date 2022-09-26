import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import UserService from "../api/UserService";
import Header from "../components/Header";

function ProfilePage() {
  const [user, setUser] = useState([]);
  const params = useParams();

  useEffect(() => {
    getUser();
  }, []);
  const getUser = () => {
    UserService.GetUserByUsername(params.username).then((res) =>
      setUser(res.data)
    );
  };
  return (
    <>
      <Header />
      <Container maxWidth="lg">
        {user.userName}'s Profile
        </Container>
    </>
  );
}

export default ProfilePage;

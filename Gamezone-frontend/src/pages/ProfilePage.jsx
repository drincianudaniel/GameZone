import { Container, Grid, Typography } from "@mui/material";
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
        <Grid container spacing={2} sx={{ mt: 2 }}>
          <Grid
            item
            xs={12}
            sm={12}
            sx={{
              borderBottom: 1,
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Typography> {user.userName}'s Profile</Typography>
          </Grid>
        </Grid>
      </Container>
    </>
  );
}

export default ProfilePage;

import { Container, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import UserService from "../api/UserService";
import Header from "../components/Header";
import ProfileMoreMenu from "../components/Menus/ProfileMoreMenu";
import UserTabbedPanel from "../components/TabbedPanels/UserTabbedPanel";
import { useUser } from "../hooks/useUser";

function ProfilePage() {
  const [profileUser, setProfileUser] = useState([]);
  const { user } = useUser();
  const params = useParams();

  useEffect(() => {
    getUser();
  }, []);
  const getUser = () => {
    UserService.GetUserByUsername(params.username).then((res) => {
      setProfileUser(res.data);
      console.log(res.data);
    });
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
            <Typography variant="h4">
              {" "}
              {profileUser.userName}'s Profile
            </Typography>
            {profileUser.userName == user.UserName && (
              <ProfileMoreMenu></ProfileMoreMenu>
            )}
          </Grid>
          <Grid
            item
            xs={12}
            md={3}
            sx={{ borderRight: { lg: 1 }, borderColor: "grey.500" }}
          >
            <Grid item xs={12} md={12} lg={12} justify="center">
              <Box
                sx={{
                  "&:hover": {
                    opacity: "0.95",
                  },
                }}
                component="img"
                alt={profileUser.userName}
                className="gameImg"
                src={profileUser.profileImageSrc}
              />
            </Grid>
          </Grid>
          <Grid
            item
            xs={12}
            sm={9}
          >
            <UserTabbedPanel profileUser={profileUser}></UserTabbedPanel>
          </Grid>
        </Grid>
      </Container>
    </>
  );
}

export default ProfilePage;

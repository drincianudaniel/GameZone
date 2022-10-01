import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import MenuIcon from "@mui/icons-material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import SportsEsportsIcon from "@mui/icons-material/SportsEsports";
import { Link } from "react-router-dom";
import AutoCompleteSearch from "./Search/AutoCompleteSearch";
import "./css/Header.css";
import { useNavigate } from "react-router-dom";
import { useUser } from "../hooks/useUser";
import GroupedSearch from "./Search/GroupedSearch";

const Header = () => {
  const [anchorElNav, setAnchorElNav] = React.useState(null);
  const [anchorElUser, setAnchorElUser] = React.useState(null);
  const { user, setUser } = useUser();
  const history = useNavigate();

  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const redirectToSearchedGame = (id) => {
    history(`/game/${id}/comments`);
  };

  const redirectToHome = () => {
    history("/");
  };

  const redirectToTop = () => {
    history("/top");
  };

  const redirectToLogin = () => {
    history("/login");
  };

  const redirectToRegister = () => {
    history("/register");
  };

  const redirectToGames = () => {
    history("/games");
  };

  const redirectToProfile = () =>{
    history(`/profile/${user.UserName}/reviews`)
  }

  const handleLogout = () => {
    history("/login");
    localStorage.clear();
    setUser([]);
  }

  const handleSearchGame = (searchGame) => {
    redirectToSearchedGame(searchGame.value);
    console.log(searchGame.value);
  };

  return (
    <AppBar position="static">
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <SportsEsportsIcon
            sx={{ display: { xs: "none", md: "flex" }, mr: 1 }}
          />
          <Link style={{ textDecoration: "none", color: "inherit" }} to="/">
            {" "}
            <Typography
              variant="h6"
              noWrap
              component="a"
              sx={{
                mr: 2,
                display: { xs: "none", md: "flex" },
                fontFamily: "monospace",
                fontWeight: 700,
                letterSpacing: ".3rem",
                color: "inherit",
                textDecoration: "none",
              }}
            >
              GameZone
            </Typography>
          </Link>

          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: "block", md: "none" },
              }}
            >
              <MenuItem onClick={handleCloseNavMenu}>
                <Typography onClick={redirectToHome} textAlign="center">
                  Home
                </Typography>
              </MenuItem>
              <MenuItem onClick={handleCloseNavMenu}>
                <Typography onClick={redirectToGames} textAlign="center">
                  Games
                </Typography>
              </MenuItem>
              <MenuItem onClick={handleCloseNavMenu}>
                <Typography onClick={redirectToTop} textAlign="center">
                  Top
                </Typography>
              </MenuItem>
            </Menu>
          </Box>
          <SportsEsportsIcon sx={{ display: { xs: "none" }, mr: 1 }} />
          <Typography
            variant="h5"
            noWrap
            component="a"
            sx={{
              mr: 2,
              display: { md: "none", xs: "none" },
              flexGrow: 1,
              fontFamily: "monospace",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            GameZone
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            <Link style={{ textDecoration: "none" }} to="/">
              <Button
                onClick={handleCloseNavMenu}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {" "}
                Home{" "}
              </Button>
            </Link>
            <Link style={{ textDecoration: "none" }} to="/games">
              <Button
                onClick={handleCloseNavMenu}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {" "}
                Games{" "}
              </Button>
            </Link>
            <Link style={{ textDecoration: "none" }} to="/top">
              <Button
                onClick={handleCloseNavMenu}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {" "}
                Top{" "}
              </Button>
            </Link>
          </Box>
          <Box sx={{ marginRight: 4, color: "black" }}>
            <AutoCompleteSearch handleSearchGame={handleSearchGame} />
            {/* <GroupedSearch></GroupedSearch> */}
          </Box>
          <Box sx={{ flexGrow: 0 }}>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar alt="Remy Sharp" src={user.ProfileImage} />
              </IconButton>
            </Tooltip>
            {user.IsLoggedIn && (
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem onClick={redirectToProfile}>
                  <Typography textAlign="center">Profile</Typography>
                </MenuItem>
                <MenuItem onClick={handleLogout}>
                  <Typography textAlign="center">Logout</Typography>
                </MenuItem>
              </Menu>
            )}
            {!user.IsLoggedIn && (
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem onClick={redirectToLogin}>
                  <Typography textAlign="center">Login</Typography>
                </MenuItem>
                <MenuItem onClick={redirectToRegister}>
                  <Typography textAlign="center">Register</Typography>
                </MenuItem>
              </Menu>
            )}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};
export default Header;

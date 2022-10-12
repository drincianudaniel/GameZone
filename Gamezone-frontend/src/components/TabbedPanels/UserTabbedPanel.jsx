import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import { Link, Navigate, Route, Routes, useParams } from "react-router-dom";
import FavoriteGames from "../Users/FavoriteGames";
import UserReviews from "../Users/UserReviews";

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.number.isRequired,
  value: PropTypes.number.isRequired,
};

function a11yProps(index) {
  return {
    id: `simple-tab-${index}`,
    "aria-controls": `simple-tabpanel-${index}`,
  };
}

function LinkTab(props) {
  return <Tab component={Link} to={props.pathname} {...props} />;
}

export default function UserTabbedPanel(props) {
  const [value, setValue] = React.useState(0);
  const params = useParams();

  //   React.useEffect(() => {
  //     let path = window.location.pathname;

  //     if (path === `/game/${params.id}/comments` && value !== 0) setValue(0);
  //     else if (path === `/game/${params.id}/reviews` && value !== 1) setValue(1);
  //   }, [value]);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <Box sx={{ width: "100%" }}>
      <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="basic tabs example"
        >
          <LinkTab
            label="Reviews"
            pathname={`/profile/${params.username}/reviews`}
            {...a11yProps(0)}
          />
          <LinkTab
            label="Favorite Games"
            pathname={`/profile/${params.username}/favorite-games`}
            {...a11yProps(1)}
          />
        </Tabs>
      </Box>
      <Box sx={{ padding: { sm: "24px", xs: "5px" } }}>
        {/* <TabPanel value={value} index={0}>
          <Comments />
        </TabPanel>
        <TabPanel value={value} index={1}>
          <Reviews getGame={props.getGame} />
        </TabPanel> */}
        <Routes>
          <Route path={"reviews"} element={<UserReviews />} />
          <Route
            path={"favorite-games"}
            element={<FavoriteGames profileUser={props.profileUser} />}
          />
          <Route path={"*"} element={<Navigate to="/notfound" replace />} />
        </Routes>
      </Box>
    </Box>
  );
}

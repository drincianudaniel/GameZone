import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import AddGameForm from "../Forms/AddGameForm";
import DevelopersTabbedPanel from "./DevelopersTabbedPanel";
import { Link, Route, Routes } from "react-router-dom";
import GenresTabbedPanel from "./GenresTabbedPanel";
import PlatformsTabbedPanel from "./PlatformsTabbedPanel";
import Users from "../Users/Users";
import GameCharts from "../Charts/GameCharts";

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
        <Box>
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

export default function BasicTabs() {
  const [value, setValue] = React.useState(0);
  React.useEffect(() => {
    let path = window.location.pathname;

    if (path === "/admin-page/add-game" && value !== 0) setValue(0);
    else if (path === "/admin-page/developers" && value !== 1) setValue(1);
    else if (path === "/admin-page/developers/add-developer" && value !== 1)
      setValue(1);
    else if (path === "/admin-page/developers/list" && value !== 1) setValue(1);
    else if (path === "/admin-page/genres" && value !== 2) setValue(2);
    else if (path === "/admin-page/genres/add-genre" && value !== 2)
      setValue(2);
    else if (path === "/admin-page/genres/list" && value !== 2) setValue(2);
    else if (path === "/admin-page/add-platform" && value !== 3) setValue(3);
    else if (path === "/admin-page/platforms/add-platform" && value !== 3)
      setValue(3);
    else if (path === "/admin-page/platforms/list" && value !== 3) setValue(3);
  }, [value]);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <Box>
      <Box
        sx={{ borderBottom: 1, borderColor: "divider" }}
        display="flex"
        justifyContent="center"
        alignItems="center"
      >
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="basic tabs example"
          TabIndicatorProps={{ sx: { display: "none" } }}
          sx={{
            "& .MuiTabs-flexContainer": {
              flexWrap: "wrap",
            },
          }}
        >
          <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Add game"
            pathname="/admin-page/add-game"
            {...a11yProps(0)}
          />
          <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Developers"
            pathname="/admin-page/developers/add-developer"
            {...a11yProps(1)}
          />
          <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Genres"
            pathname="/admin-page/genres/add-genre"
            {...a11yProps(2)}
          />
          <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Platforms"
            pathname="/admin-page/platforms/add-platform"
            {...a11yProps(3)}
          />
          <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Users"
            pathname="/admin-page/users"
            {...a11yProps(3)}
          />
           <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Charts"
            pathname="/admin-page/charts"
            {...a11yProps(4)}
          />
        </Tabs>
      </Box>
      <Box>
        <Routes>
          <Route
            path={"add-game"}
            element={
              <Box sx={{ padding: { xs: "10px" } }}>
                <AddGameForm />
              </Box>
            }
          />

          <Route path={"developers/*"} element={<DevelopersTabbedPanel />} />
          <Route path={"genres/*"} element={<GenresTabbedPanel />} />
          <Route path={"platforms/*"} element={<PlatformsTabbedPanel />} />
          <Route path={"users"} element={<Users />} />
          <Route path={"charts"} element={<GameCharts />} />
        </Routes>
      </Box>
    </Box>
  );
}

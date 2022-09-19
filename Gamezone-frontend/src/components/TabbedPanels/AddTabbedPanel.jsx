import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import AddGameForm from "../Forms/AddGameForm";
import AddGenreForm from "../Forms/AddGenreForm";
import AddPlatformForm from "../Forms/AddPlatformForm";
import AddDeveloperForm from "../Forms/AddDeveloperForm";
import DevelopersTabbedPanel from "./DevelopersTabbedPanel";
import { Link, Route, Routes } from "react-router-dom";

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
  return (
    <Tab
      component={Link}
      to={props.pathname}
      {...props}
    />
  );
}

export default function BasicTabs() {
  const [value, setValue] = React.useState(0);

  React.useEffect(() => {
    let path = window.location.pathname;

    if (path === "/admin-page/add-game" && value !== 0) setValue(0);
    else if (path === "/admin-page/developers" && value !== 1) setValue(1);
    else if (path === "/admin-page/add-genre" && value !== 2) setValue(2);
    else if (path === "/admin-page/add-platform" && value !== 3) setValue(3);
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
            label="Add genre"
            pathname="/admin-page/add-genre"
            {...a11yProps(2)}
          />
          <LinkTab
            sx={{ fontWeight: "bold" }}
            label="Add platform"
            pathname="/admin-page/add-platform"
            {...a11yProps(3)}
          />
        </Tabs>
      </Box>
      <Routes>
        <Route path={"add-game"} element={<AddGameForm />} />
        <Route path={":developers/*"} element={<DevelopersTabbedPanel />} />
        <Route path={"add-genre"} element={<AddGenreForm />} />
        <Route path={"add-platform"} element={<AddPlatformForm />} />
      </Routes>
    </Box>
  );
}

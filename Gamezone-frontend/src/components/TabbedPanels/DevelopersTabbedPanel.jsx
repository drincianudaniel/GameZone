import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import AddDeveloperForm from "../Forms/AddDeveloperForm";
import DevelopersList from "../Lists/DevelopersList";
import Developers from "../Developers/Developers";
import { Route, Routes } from "react-router";
import { Link } from "react-router-dom";

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
  console.log(props);
  return (
    <Tab
      component={Link}
      //   onClick={(event) => {
      //     event.preventDefault();
      //   }}
      to={props.pathname}
      {...props}
    />
  );
}

export default function DevelopersTabbedPanel() {
  const [value, setValue] = React.useState(0);

  React.useEffect(() => {
    let path = window.location.pathname;

    if (path === "/admin-page/developers/add-developer" && value !== 0) setValue(0);
    else if (path === "/admin-page/developers/list" && value !== 1) setValue(1);
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
            label="Add developer"
            pathname="/admin-page/developers/add-developer"
            {...a11yProps(0)}
          />
          <LinkTab
            label="Developers list"
            pathname="/admin-page/developers/list"
            {...a11yProps(1)}
          />
        </Tabs>
      </Box>
      {/* <TabPanel value={value} index={0}>
        <AddDeveloperForm />
      </TabPanel>
      <TabPanel value={value} index={1}>
        <Developers />
      </TabPanel> */}
      <Routes>
        <Route path={"add-developer"} element={<AddDeveloperForm />} />
        <Route path={"list"} element={<Developers />} />
      </Routes>
    </Box>
  );
}

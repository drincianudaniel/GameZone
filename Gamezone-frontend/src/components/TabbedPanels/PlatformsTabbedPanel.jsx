import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import { Route, Routes } from "react-router";
import { Link } from "react-router-dom";
import AddPlatformForm from "../Forms/AddPlatformForm";
import Platforms from "../Platforms/Platforms";

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

export default function PlatformsTabbedPanel() {
  const [value, setValue] = React.useState(0);

  React.useEffect(() => {
    let path = window.location.pathname;

    if (path === "/admin-page/platforms/add-platform" && value !== 0)
      setValue(0);
    else if (path === "/admin-page/platforms/list" && value !== 1) setValue(1);
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
            label="Add platform"
            pathname="/admin-page/platforms/add-platform"
            {...a11yProps(0)}
          />
          <LinkTab
            label="Platform list"
            pathname="/admin-page/platforms/list"
            {...a11yProps(1)}
          />
        </Tabs>
      </Box>
      <Box sx={{ padding: { xs: "10px" } }}>
        {" "}
        <Routes>
          <Route path={"add-platform"} element={<AddPlatformForm />} />
          <Route path={"list"} element={<Platforms />} />
        </Routes>
      </Box>
    </Box>
  );
}

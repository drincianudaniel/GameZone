import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import Reviews from "../Reviews/Reviews";
import Comments from "../Comments/Comments";
import { Link, Navigate, Route, Routes, useParams } from "react-router-dom";

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

export default function DetailsTabbedPanel(props) {
  const [value, setValue] = React.useState(0);
  const params = useParams();

  React.useEffect(() => {
    let path = window.location.pathname;

    if (path === `/game/${params.id}/comments` && value !== 0) setValue(0);
    else if (path === `/game/${params.id}/reviews` && value !== 1) setValue(1);
  }, [value]);

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
            label="Comments"
            pathname={`/game/${params.id}/comments`}
            {...a11yProps(0)}
          />
          <LinkTab
            label="Reviews"
            pathname={`/game/${params.id}/reviews`}
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
          <Route path={"comments"} element={<Comments />} />
          <Route
            path={"reviews"}
            element={<Reviews getGame={props.getGame} />}
          />
          <Route path={"*"} element={<Navigate to="/notfound" replace />} />
        </Routes>
      </Box>
    </Box>
  );
}

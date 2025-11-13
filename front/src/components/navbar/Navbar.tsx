
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';

import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from "react-router";
const Navbar = () => {

    return(
    <Box sx={{ flexGrow: 1  }}>
      <AppBar position="fixed" 
        sx={{
        backgroundColor: "black"
  }}>
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Link to="/" style={{ flexGrow: 1 ,color : "white" }}>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Home
          </Typography>
          </Link>
        </Toolbar>
      </AppBar>
    </Box>

    )

}

export default Navbar
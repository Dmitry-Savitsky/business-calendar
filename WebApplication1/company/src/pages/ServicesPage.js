// import React, { useEffect, useState } from "react";
// import { getAllServices, createService } from "../http/ServicesApi.js";
// import { observer } from "mobx-react-lite";
// import { jwtDecode } from 'jwt-decode';
// import ServiceCard from "../components/ServiceCard.js";
// import { Container, Row, Col, Button } from "react-bootstrap";

// const ServicesPage = () => {
//   const [services, setServices] = useState([]);
//   const token = localStorage.getItem('token');
//   const decodedToken = token ? jwtDecode(token) : null;
//   const isAdmin = decodedToken && decodedToken.role === "Admin";

//   // Define the fetchData function outside the useEffect
//   const fetchData = async () => {
//     try {
//       const data = await getAllServices();
//       console.log('All Services:', data);
//       setServices(data);
//     } catch (error) {
//       console.error('Error fetching data:', error);
//     }
//   };

//   useEffect(() => {
//     // Call fetchData function when the component mounts
//     fetchData();
//   }, []);

//   const handleServiceUpdate = () => {
//     // Call fetchData function after service update
//     fetchData();
//   };

//   // Function to handle the creation of a new service
//   const handleAddService = async () => {
//     try {
//       // Define the new service object
//       const newService = {
//         ServiceName: "New Service",
//         ServiceDescription: "New Service Description",
//         ServicePrice: 0 // Set the initial price as needed
//       };

//       // Call the createService function with the new service object
//       await createService(newService);

//       // After successful creation, update the services list
//       fetchData();
//     } catch (error) {
//       console.error('Error adding service:', error);
//       // Handle error as needed
//     }
//   };

//   return (
//     <Container className="px-2">
//       <Row className="mb-4 align-items-center border">
//         <Col xs={6}>
//           <h1 className="mt-4 mb-4" style={{ fontSize: "24px", color: "Black" }}>Services</h1>
//         </Col>
//         <Col xs={6} className="text-end">
//           {isAdmin && (
//             <Button variant="primary" onClick={handleAddService}>Добавить</Button>
//           )}
//         </Col>
//       </Row>
//       <Row className="mb-4">
//         {services.map(service => (
//           <Col key={service.idService} sm={6} md={4} lg={3}>
//             <ServiceCard service={service} isAdmin={isAdmin} handleServiceUpdate={handleServiceUpdate} />
//           </Col>
//         ))}
//       </Row>
//     </Container>
//   );
// };

// export default observer(ServicesPage);

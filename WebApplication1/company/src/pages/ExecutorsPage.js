// import React, { useEffect, useState } from "react";
// import { getAllEmployees, createEmployee } from "../http/employeesApi.js";
// import { observer } from "mobx-react-lite";
// import { jwtDecode } from 'jwt-decode';
// import EmployeeCard from "../components/EmployeeCard.js";
// import { Container, Row, Col, Button } from "react-bootstrap";

// const EmployeesPage = () => {
//   const [employees, setEmployees] = useState([]);
//   const token = localStorage.getItem('token');
//   const decodedToken = token ? jwtDecode(token) : null;
//   const isAdmin = decodedToken && decodedToken.role === "Admin";

//   // Define the fetchData function outside the useEffect
//   const fetchData = async () => {
//     try {
//       const data = await getAllEmployees();
//       console.log('All Employees:', data);
//       setEmployees(data);
//     } catch (error) {
//       console.error('Error fetching data:', error);
//     }
//   };

//   useEffect(() => {
//     // Call fetchData function when the component mounts
//     fetchData();
//   }, []);

//   const handleEmployeeUpdate = () => {
//     // Call fetchData function after employee update
//     fetchData();
//   };

//   // Function to handle the creation of a new employee
//   const handleAddEmployee = async () => {
//     try {
//       // Define the new employee object
//       const newEmployee = {
//         EmployeeName: "New Employee",
//         EmployeePhone: "New Phone",
//         EmployeeAddress: "New Address",
//         EmployeeStatus: "New Status",
//         EmployeeExperience: 0 // Set the initial experience as needed
//       };

//       // Call the createEmployee function with the new employee object
//       await createEmployee(newEmployee);

//       // After successful creation, update the employees list
//       fetchData();
//     } catch (error) {
//       console.error('Error adding employee:', error);
//       // Handle error as needed
//     }
//   };

//   return (
//     <Container className="px-2">
//       <Row className="mb-4 align-items-center border">
//         <Col xs={6}>
//           <h1 className="mt-4 mb-4" style={{ fontSize: "24px", color: "Black" }}>Employees</h1>
//         </Col>
//         <Col xs={6} className="text-end">
//           {isAdmin && (
//             <Button variant="primary" onClick={handleAddEmployee}>Добавить</Button>
//           )}
//         </Col>
//       </Row>
//       <Row className="mb-4">
//         {employees.map(employee => (
//           <Col key={employee.idEmployee} sm={6} md={4} lg={3}>
//             <EmployeeCard employee={employee} isAdmin={isAdmin} handleEmployeeUpdate={handleEmployeeUpdate} />
//           </Col>
//         ))}
//       </Row>
//     </Container>
//   );
// };

// export default observer(EmployeesPage);

// import React, { useEffect, useState } from "react";
// import { getAllAccountings, createAccounting, getAllAccountingsByClientId } from "../http/accountingApi";
// import { observer } from "mobx-react-lite";
// import { jwtDecode } from 'jwt-decode';
// import AccountingCard from "../components/AccountingCard";
// import AddAccountingForm from "../components/AddAccountingForm";
// import { Container, Row, Col, Button } from "react-bootstrap";
// import { PDFViewer } from '@react-pdf/renderer';
// import AccountingsReport from "../components/AccountingsReport";

// const AccountingPage = () => {
//     const [accountings, setAccountings] = useState([]);
//     const [showAddForm, setShowAddForm] = useState(false);

//     const token = localStorage.getItem('token');
//     const decodedToken = token ? jwtDecode(token) : null;
//     const isAdmin = decodedToken && decodedToken.role === "Admin";
//     const clientId = decodedToken.idclnt;


//     const [showReport, setShowReport] = useState(false);
//     const handleGenerateReport = () => {
//         setShowReport(true);
//     };

//     // Define the fetchData function outside the useEffect
//     const fetchData = async () => {
//         if (isAdmin) {
//             try {
//                 const data = await getAllAccountings();
//                 console.log('All Accountings:', data);
//                 setAccountings(data);
//             } catch (error) {
//                 console.error('Error fetching data:', error);
//             }
//         }
//         else {
//             console.log("CLIENTID:" + clientId)
//             try {
//                 const data = await getAllAccountingsByClientId(clientId);
//                 console.log('All Client Accountings:', data);
//                 setAccountings(data);
//             } catch (error) {
//                 console.error('Error fetching data:', error);
//             }
//         }

//     };

//     useEffect(() => {
//         // Call fetchData function when the component mounts
//         fetchData();
//     }, []);

//     // Function to handle the creation of a new accounting
//     const handleAddAccounting = async (formData) => {
//         try {
//             // Call the createAccounting function to add a new accounting
//             await createAccounting(formData);

//             // After successful creation, update the accountings list
//             fetchData();
//         } catch (error) {
//             console.error('Error adding accounting:', error);
//             // Handle error as needed
//         }
//     };

//     const handleAccountingUpdate = () => {
//         // Call fetchData function after service update
//         fetchData();
//     };

//     return (
//         <Container className="px-2">
//             <Row className="mb-4 align-items-center border">
//                 <Col xs={6}>
//                     <h1 className="mt-4 mb-4" style={{ fontSize: "24px", color: "Black" }}>
//                         Accountings
//                     </h1>
//                 </Col>
//                 <Col xs={6} className="text-end">
//                     {isAdmin && (
//                         <Button variant="primary" onClick={handleGenerateReport}>
//                             Сгенерировать отчет
//                         </Button>

//                     )}
//                     {isAdmin && (
//                         <Button
//                             className="ms-2"
//                             variant="primary"
//                             onClick={() => setShowAddForm(true)}
//                         >
//                             Добавить
//                         </Button>
//                     )}
//                 </Col>
//             </Row>
//             <Row className="mb-4">
//                 {accountings.map(accounting => (
//                     <Col key={accounting.idAccounting} sm={6} md={4} lg={3}>
//                         <AccountingCard accounting={accounting} isAdmin={isAdmin} handleAccountingUpdate={handleAccountingUpdate} />
//                     </Col>
//                 ))}
//             </Row>
//             {/* Add the AddAccountingForm component */}
//             <AddAccountingForm
//                 show={showAddForm}
//                 handleClose={() => setShowAddForm(false)}
//                 handleAdd={handleAddAccounting}
//             />

//             {showReport && (
//                 <PDFViewer width="1320" height="600">
//                     <AccountingsReport accountings={accountings} />
//                 </PDFViewer>
//             )}

//         </Container>
//     );
// };

// export default observer(AccountingPage);

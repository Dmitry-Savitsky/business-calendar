import React, { useState, useEffect } from 'react';
import { fetchServices, createService, deleteService } from '../http/serviceApi'; // Проверьте правильность пути
import { fetchExecutors } from '../http/executorApi'; // Проверьте правильность пути
import { fetchExecutorHasServices, createExecutorHasService, deleteExecutorHasService } from '../http/executorHasServiceApi'; // Проверьте правильность пути
import { Button, Form, Container, Row, Col, Table } from 'react-bootstrap';

const ServicesPage = () => {
    const [services, setServices] = useState([]);
    const [executors, setExecutors] = useState([]);
    const [executorHasServices, setExecutorHasServices] = useState([]);
    const [serviceName, setServiceName] = useState('');
    const [serviceType, setServiceType] = useState('');
    const [servicePrice, setServicePrice] = useState('');
    const [selectedExecutor, setSelectedExecutor] = useState('');
    const [selectedService, setSelectedService] = useState('');

    useEffect(() => {
        loadServices();
        loadExecutors();
        loadExecutorHasServices();
    }, []);

    const loadServices = async () => {
        try {
            const data = await fetchServices();
            setServices(data.$values || []);
        } catch (error) {
            console.error(error);
        }
    };

    const loadExecutors = async () => {
        try {
            const data = await fetchExecutors();
            setExecutors(data.$values || []);
        } catch (error) {
            console.error(error);
        }
    };

    const loadExecutorHasServices = async () => {
        try {
            const data = await fetchExecutorHasServices();
            setExecutorHasServices(data.$values || []);
        } catch (error) {
            console.error(error);
        }
    };

    const handleCreateService = async () => {
        try {
            await createService({ serviceName, serviceType, servicePrice });
            loadServices();
            setServiceName('');
            setServiceType('');
            setServicePrice('');
        } catch (error) {
            console.error(error);
        }
    };

    const handleDeleteService = async (idService) => {
        try {
            await deleteService(idService);
            loadServices();
        } catch (error) {
            console.error(error);
        }
    };

    const handleAssignExecutor = async () => {
        try {
            await createExecutorHasService({ idExecutor: selectedExecutor, idService: selectedService });
            loadExecutorHasServices();
            setSelectedExecutor('');
            setSelectedService('');
        } catch (error) {
            console.error(error);
        }
    };

    const handleDeleteExecutorHasService = async (idExecutor, idService) => {
        try {
            await deleteExecutorHasService(idExecutor, idService);
            loadExecutorHasServices();
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Container>
            <Row className="my-4">
                <Col>
                    <h1>Services</h1>
                </Col>
            </Row>
            <Row className="mb-4">
                <Col md={6}>
                    <Form>
                        <Form.Group controlId="serviceName">
                            <Form.Label>Service Name</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter service name"
                                value={serviceName}
                                onChange={(e) => setServiceName(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="serviceType">
                            <Form.Label>Service Type</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter service type"
                                value={serviceType}
                                onChange={(e) => setServiceType(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="servicePrice">
                            <Form.Label>Service Price</Form.Label>
                            <Form.Control
                                type="number"
                                placeholder="Enter service price"
                                value={servicePrice}
                                onChange={(e) => setServicePrice(e.target.value)}
                            />
                        </Form.Group>
                        <Button variant="primary" onClick={handleCreateService} className="mt-3">
                            Add Service
                        </Button>
                    </Form>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Name</th>
                                <th>Type</th>
                                <th>Price</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {services.map((service, index) => (
                                <tr key={service.idService}>
                                    <td>{index + 1}</td>
                                    <td>{service.serviceName}</td>
                                    <td>{service.serviceType}</td>
                                    <td>{service.servicePrice}</td>
                                    <td>
                                        <Button
                                            variant="danger"
                                            onClick={() => handleDeleteService(service.idService)}
                                        >
                                            Delete
                                        </Button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </Col>
            </Row>
            <Row className="my-4">
                <Col>
                    <h1>Assign Executor to Service</h1>
                </Col>
            </Row>
            <Row className="mb-4">
                <Col md={6}>
                    <Form>
                        <Form.Group controlId="selectExecutor">
                            <Form.Label>Select Executor</Form.Label>
                            <Form.Control
                                as="select"
                                value={selectedExecutor}
                                onChange={(e) => setSelectedExecutor(e.target.value)}
                            >
                                <option value="">Select Executor</option>
                                {executors.map((executor) => (
                                    <option key={executor.idExecutor} value={executor.idExecutor}>
                                        {executor.executorName}
                                    </option>
                                ))}
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="selectService" className="mt-3">
                            <Form.Label>Select Service</Form.Label>
                            <Form.Control
                                as="select"
                                value={selectedService}
                                onChange={(e) => setSelectedService(e.target.value)}
                            >
                                <option value="">Select Service</option>
                                {services.map((service) => (
                                    <option key={service.idService} value={service.idService}>
                                        {service.serviceName}
                                    </option>
                                ))}
                            </Form.Control>
                        </Form.Group>
                        <Button variant="primary" onClick={handleAssignExecutor} className="mt-3">
                            Assign Executor
                        </Button>
                    </Form>
                </Col>
            </Row>
            <Row className="my-4">
                <Col>
                    <h1>Executor Has Services</h1>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Executor ID</th>
                                <th>Service ID</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {executorHasServices.map((ehs, index) => (
                                <tr key={`${ehs.idExecutor}-${ehs.idService}`}>
                                    <td>{index + 1}</td>
                                    <td>{ehs.idExecutor}</td>
                                    <td>{ehs.idService}</td>
                                    <td>
                                        <Button
                                            variant="danger"
                                            onClick={() => handleDeleteExecutorHasService(ehs.idExecutor, ehs.idService)}
                                        >
                                            Delete
                                        </Button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </Col>
            </Row>
        </Container>
    );
};

export default ServicesPage;
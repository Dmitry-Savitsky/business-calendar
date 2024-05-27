import React, { useState, useEffect } from 'react';
import { fetchExecutors, createExecutor, deleteExecutor } from '../http/executorApi'; // Проверьте правильность пути
import { Button, Form, Container, Row, Col, Table } from 'react-bootstrap';

const ExecutorsPage = () => {
    const [executors, setExecutors] = useState([]);
    const [executorName, setExecutorName] = useState('');
    const [executorPhone, setExecutorPhone] = useState('');

    useEffect(() => {
        loadExecutors();
    }, []);

    const loadExecutors = async () => {
        try {
            const data = await fetchExecutors();
            setExecutors(data.$values || []);
        } catch (error) {
            console.error(error);
        }
    };

    const handleCreateExecutor = async () => {
        try {
            await createExecutor({ executorName, executorPhone });
            loadExecutors();
            setExecutorName('');
            setExecutorPhone('');
        } catch (error) {
            console.error(error);
        }
    };

    const handleDeleteExecutor = async (idExecutor) => {
        try {
            await deleteExecutor(idExecutor);
            loadExecutors();
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Container>
            <Row className="my-4">
                <Col>
                    <h1>Executors</h1>
                </Col>
            </Row>
            <Row className="mb-4">
                <Col md={6}>
                    <Form>
                        <Form.Group controlId="executorName">
                            <Form.Label>Executor Name</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter executor name"
                                value={executorName}
                                onChange={(e) => setExecutorName(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="executorPhone">
                            <Form.Label>Executor Phone</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter executor phone"
                                value={executorPhone}
                                onChange={(e) => setExecutorPhone(e.target.value)}
                            />
                        </Form.Group>
                        <Button variant="primary" onClick={handleCreateExecutor} className="mt-3">
                            Add Executor
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
                                <th>Phone</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {executors.map((executor, index) => (
                                <tr key={executor.idExecutor}>
                                    <td>{index + 1}</td>
                                    <td>{executor.executorName}</td>
                                    <td>{executor.executorPhone}</td>
                                    <td>
                                        <Button
                                            variant="danger"
                                            onClick={() => handleDeleteExecutor(executor.idExecutor)}
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

export default ExecutorsPage;
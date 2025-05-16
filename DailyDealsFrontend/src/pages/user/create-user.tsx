import React from 'react';
import {
  Box,
  Button,
  Input,
  Heading,
  VStack,
  FieldsetRoot,
  FieldsetLegend,
  FieldsetErrorText,
} from '@chakra-ui/react';
import { useForm } from 'react-hook-form';

const UserRegistrationForm = () => {
  const {
    handleSubmit,
    register,
    formState: { errors },
    reset
  } = useForm();

  const onSubmit = () => {
    // Aqui você pode fazer a chamada para a API
    reset();
  };

  return (
    <Box mt={10} p={6} borderWidth={1} borderRadius="lg" boxShadow="md">
      <Heading size="lg" mb={6} textAlign="center">
        Cadastro de Usuário
      </Heading>
      <form onSubmit={handleSubmit(onSubmit)}>
          <FieldsetRoot>
            <FieldsetLegend>Nome</FieldsetLegend>
            <Input
              placeholder="Digite seu nome"
              {...register('name', { required: 'Nome é obrigatório' })}
            />
          </FieldsetRoot>

          <FieldsetRoot>
            <FieldsetLegend>Email</FieldsetLegend>
            <Input
              type="email"
              placeholder="Digite seu email"
              {...register('email', {
                required: 'Email é obrigatório',
                pattern: {
                  value: /^\S+@\S+$/i,
                  message: 'Email inválido',
                },
              })}
            />
            <FieldsetErrorText></FieldsetErrorText>
          </FieldsetRoot>

          <FieldsetRoot>
            <FieldsetLegend>Senha</FieldsetLegend>
            <Input
              type="password"
              placeholder="Digite sua senha"
              {...register('password', {
                required: 'Senha é obrigatória',
                minLength: { value: 6, message: 'Mínimo 6 caracteres' },
              })}
            />
          </FieldsetRoot>

          <FieldsetRoot>
            <FieldsetLegend>CPF</FieldsetLegend>
            <Input
              placeholder="Digite seu CPF"
              {...register('cpf', {
                required: 'CPF é obrigatório',
                pattern: {
                  value: /^\d{11}$/,
                  message: 'CPF deve conter 11 dígitos numéricos',
                },
              })}
            />
          </FieldsetRoot>

          <Button mt={2} type="submit" colorScheme="blue" width="full">
            Cadastrar
          </Button>
      </form>
    </Box>
  );
};

export default UserRegistrationForm;
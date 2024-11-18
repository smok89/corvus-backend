#!/bin/bash

# Load environment variables from .env file
source .env

# Drop the existing database
echo "Dropping the existing database..."
PGPASSWORD=$POSTGRES_PASSWORD psql -U $POSTGRES_USER -h $POSTGRES_HOST -c "DROP DATABASE IF EXISTS $POSTGRES_DB;"
if [ $? -ne 0 ]; then
    echo "Failed to drop the database."
    exit 1
else
    echo "Database dropped successfully."
fi

# Recreate the database
echo "Creating a new database..."
PGPASSWORD=$POSTGRES_PASSWORD psql -U $POSTGRES_USER -h $POSTGRES_HOST -c "CREATE DATABASE $POSTGRES_DB;"
if [ $? -ne 0 ]; then
    echo "Failed to create the database."
    exit 1
else
    echo "Database created successfully."
fi

# Run the migrations
echo "Running the migrations..."
dotnet ef database update
if [ $? -ne 0 ]; then
    echo "Failed to run the migrations."
    exit 1
else
    echo "Migrations run successfully."
fi
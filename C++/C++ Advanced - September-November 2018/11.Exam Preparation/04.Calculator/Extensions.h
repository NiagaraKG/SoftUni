#ifndef EXTENSIONS_H
#define EXTENSIONS_H

#include "CalculationEngine.h"
#include "InputInterpreter.h"
#include "Operation.h"

#include <memory>
#include <stack>

class OperationwithResult : public Operation
{
protected:
	int result;
	bool complited = false;
public:
	 int getResult() override {
		return this->result;
	}

	bool isCompleted() override
	{
		return this->complited;
	}
};

class MemorySaveOperation : public OperationwithResult
{
	std::shared_ptr<std::stack<int> > memory;
public:
	MemorySaveOperation(std::shared_ptr<std::stack<int> > memory) : memory(memory) {}

	void addOperand(int operand) override
	{
		this->memory->push(operand);
		this->result = operand;
		this->complited = true;
	}
};

class MemoryReadOperation : public OperationwithResult
{
public:
	MemoryReadOperation(std::shared_ptr<std::stack<int> > memory)
	{
		this->complited = true;
		this->result = memory->top();
		memory->pop();
	}
	void addOperand(int operand) override {}
};

class DivisionOperation : public OperationwithResult
{
	bool hasfirstoperand = false;
	int firstoperand;
public:
	void addOperand(int operand) override {
		if (this->hasfirstoperand) {
			this->result = this->firstoperand / operand;
			this->complited = true;
		}
		else
		{
			this->firstoperand = operand;
			this->hasfirstoperand = true;
		}
	}
};

class ExtendetInputInterpreter : public InputInterpreter
{
	std::shared_ptr<std::stack<int> > memory = std::make_shared<std::stack<int> >();
public:
	ExtendetInputInterpreter(CalculationEngine& engine) : InputInterpreter(engine) {}

	std::shared_ptr<Operation> getOperation(std::string operation) override
	{
		std::shared_ptr<Operation> o = InputInterpreter::getOperation(operation);
		
		if (o)
		{
			return o;
		}
		else if(operation == "/")
		{
			return std::make_shared<DivisionOperation>();
		}
		else if (operation == "ms")
		{
			return std::make_shared<MemorySaveOperation>(memory);
		}
		else if (operation == "mr")
		{
			return std::make_shared<MemoryReadOperation>(memory);
		}
		return nullptr;
	}
};

std::shared_ptr<InputInterpreter> buildInterpreter(CalculationEngine& engine)
{
	return std::make_shared<ExtendetInputInterpreter>(engine);
}

#endif

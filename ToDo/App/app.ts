import {Component, View, bootstrap, NgFor, NgClass, NgIf} from "angular2/angular2"

class TodoItem {
    public value: string;
    public done: boolean;

    constructor(message: string, done: boolean = false){
        this.value = message;
        this.done = done;
    }

    public getStatusText() : string {
        return this.done ? "done" : "not-done";
    }
}

@Component({
    selector: "todo-app"
})
@View({
    directives: [NgFor, NgClass, NgIf],
    template: ` <h2>Todos</h2>
                <div>
                    <label>Status:</label> {{getSolvedTodosCount()}}/{{todos.length}}
                    <label *ng-if="getSolvedTodosCount() == todos.length">
                        Congratulations - We're done!
                    </label>
                </div>
                <div>
                    <label for="todo-input">Todo:</label>
                    <input type="text" name="todo-input" #todo-input (keyup)="onKeyPress($event, todoInput)"/>
                    <input type="button" value="Add" (click)="onAddTodoClick(todoInput)"/>
                    <input type="button" value="Complete all" (click)="onCompleteAll()"/>
                </div>
                <ul>
                    <li *ng-for="#todo of todos">
                        <span [ng-class]="todo.getStatusText()">{{todo.value}}</span>
                        <input #todo-checkbox type="checkbox" [checked]="todo.done" (change)="onCheckboxChange(todoCheckbox, todo)"/>
                        <a href="#" (click)="onRemoveTodoClick(todo)">x</a>
                    </li>
                </ul>
              `
})
class TodoApp{
    public todos: TodoItem[];

    constructor(){
        this.todos = [new TodoItem("Learn Angular 2", true), new TodoItem("Learn React")];
    }

    public getSolvedTodosCount(){
        return this.todos.reduce((aggregated, item)=>{
            return aggregated + (item.done ? 1 : 0);
        }, 0);
    }

    public onRemoveTodoClick(todoItem: TodoItem): boolean{
        var index = this.todos.findIndex((item) => item == todoItem);

        if(index != -1){
            this.todos.splice(index, 1);
        }

        return false;
    }

    public onCheckboxChange(checkbox: HTMLInputElement, todoItem: TodoItem){
        todoItem.done = checkbox.checked;
    }

    public onKeyPress(event: KeyboardEvent, todoInput: HTMLInputElement): void {
        if(event.keyCode == 13){
            this.addTodo(todoInput);
        }
    }

    public onAddTodoClick(todoInput: HTMLInputElement): void{
        this.addTodo(todoInput);
    }

    public onCompleteAll():void{
        this.todos.forEach((todo)=>todo.done = true);
    }

    private addTodo(todoInput: HTMLInputElement){
        if(todoInput.value.trim() == "") { return; }
        this.todos.push(new TodoItem(todoInput.value));
        todoInput.value = "";
    }
}

bootstrap(TodoApp);